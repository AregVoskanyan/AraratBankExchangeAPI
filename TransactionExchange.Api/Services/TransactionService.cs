using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TransactionExchange.Api.Data;
using TransactionExchange.Api.Data.Entities;
using TransactionExchange.Api.DTOs;
using TransactionExchange.Api.Services.Interfaces;

namespace TransactionExchange.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        public TransactionService(ApplicationDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Transaction> AddTransactionAsync(TransactionDto transactionDto)
        {
            var transaction = new Transaction()
            {
                CreatedDate = transactionDto.CreatedDate,
                ConfirmedDate = transactionDto.ConfirmedDate,
                Currency = transactionDto.Currency,
                CurrencyCode = transactionDto.CurrencyCode,
                CurrencyName = transactionDto.CurrencyName,
                ExchangeRate = transactionDto.ExchangeRate,
                Amount = transactionDto.Amount,
                ExchangedAmount = transactionDto.ExchangedAmount,
                Status = transactionDto.Status
            };

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {

            var transactionHistory = await _context.Transactions.ToListAsync();
            return transactionHistory;
        }

        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            return transaction;
        }
    }
}
