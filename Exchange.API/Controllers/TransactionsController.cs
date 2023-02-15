using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTransactionAsync()
        {
            return Ok("");
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetTransactionsAsync()
        {
            return Ok("");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionByIdAsync(int id)
        {
            return Ok("");
        }
    }
}
