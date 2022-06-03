using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxually.Models;
using Taxually.Services.VatRegistrator;

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrator _vatRegistrator;

        public VatRegistrationController(IVatRegistrator vatRegistrator)
        {
            _vatRegistrator = vatRegistrator;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> RegistrateVat([FromBody] VatRegistration request)
        {
            try
            {
                return Ok(await _vatRegistrator.RegistrateVat(request));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
