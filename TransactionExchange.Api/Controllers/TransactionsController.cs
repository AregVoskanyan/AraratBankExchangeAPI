using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TransactionExchange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            return Ok("");
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetListAsync()
        {
            return Ok("");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListAsync(int id)
        {
            return Ok("");
        }
    }
}
