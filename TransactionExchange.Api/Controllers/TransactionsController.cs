using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionExchange.Api.Data;
using TransactionExchange.Api.Data.Entities;
using TransactionExchange.Api.DTOs;
using TransactionExchange.Api.Services.Interfaces;

namespace TransactionExchange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        private readonly ITransactionService _transactionService;

        public TransactionsController(ApplicationDataContext context, ITransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody]TransactionDto transactionDto)
        {
            await _transactionService.AddTransactionAsync(transactionDto);
            return Ok("Transaction done!");
        }

        [HttpGet("AllHistory")]
        public async Task<IActionResult> GetTransactionsHistoryAsync()
        {
            var history = await _transactionService.GetAllTransactionsAsync();
            return Ok(history);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryByIdAsync(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if(transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }
    }
}
