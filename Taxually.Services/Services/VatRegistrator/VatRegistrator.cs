using System;
using System.Threading.Tasks;
using Taxually.Models;
using Taxually.Services.Clients;
using Taxually.Services.Extensions.VatRegistrationExtension; 

namespace Taxually.Services.VatRegistrator
{
    public class VatRegistrator : IVatRegistrator
    {
        private readonly ITaxuallyClient _client;
        public VatRegistrator(ITaxuallyClient client)
        {
            _client = client;
        }

        public async Task<bool> RegistrateVat(VatRegistration request)
        {
            try
            {
                if (request.Country.Equals(1))
                {
                    return await _client.PostAsync("https://api.uktax.gov.uk", request);
                }

                return request.Country.Equals(2) 
                    ? await _client.EnqueueAsync(request.GermanVat()) 
                    : await _client.EnqueueAsync(request.FranceVat());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
