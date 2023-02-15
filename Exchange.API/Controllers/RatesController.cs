using Exchange.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RatesController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rates = await _rateService.GetAsync();
            if(rates == null)
            {
                return StatusCode(503, "Rates are not available");
            }
            return Ok(rates);
        }
    }
}
