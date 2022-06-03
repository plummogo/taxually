using System.Threading.Tasks;
using Taxually.Models.Models.Response;
using Taxually.Services.Clients;

namespace Taxually.TechnicalTest
{
    public class TaxuallyClient: ITaxuallyClient
    {
        public Task<bool> PostAsync<TRequest>(string url, TRequest request)
        {
            return (Task<bool>)Task.CompletedTask;
        }

        public Task<bool> EnqueueAsync<TPayload>(VatResponse<TPayload> vatResponse)
        {
            return (Task<bool>)Task.CompletedTask;
        }
    }
}
