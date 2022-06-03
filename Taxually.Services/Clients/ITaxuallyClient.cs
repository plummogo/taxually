using System.Threading.Tasks;
using Taxually.Models.Models.Response;

namespace Taxually.Services.Clients
{
    interface ITaxuallyClient
    {
        Task<bool> PostAsync<TRequest>(string url, TRequest request);
        Task<bool> EnqueueAsync<TPayload>(VatResponse<TPayload> vatResponse);
    }
}
