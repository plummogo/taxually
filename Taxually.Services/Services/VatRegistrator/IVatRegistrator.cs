using System.Threading.Tasks;
using Taxually.Models;

namespace Taxually.Services.VatRegistrator
{
    public interface IVatRegistrator
    {
        Task<bool> RegistrateVat(VatRegistration request);
    }
}
