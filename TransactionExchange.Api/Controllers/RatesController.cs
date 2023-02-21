using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading.Tasks;
using TransactionExchange.Api.Helpers;
using TransactionExchange.Api.Services.Interfaces;

namespace TransactionExchange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
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
            if (rates == null)
            {
                return StatusCode(503, "Rates are not available");
            }
            return Ok(rates);
        }
    }
}
