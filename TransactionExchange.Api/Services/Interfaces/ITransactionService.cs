using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionExchange.Api.Data.Entities;
using TransactionExchange.Api.DTOs;

namespace TransactionExchange.Api.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> AddTransactionAsync(TransactionDto transactionDto);
        Task<List<Transaction>> GetAllTransactionsAsync();
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
    }
}
