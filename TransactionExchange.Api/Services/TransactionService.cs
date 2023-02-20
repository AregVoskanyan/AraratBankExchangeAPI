using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog.Layouts;
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
        private readonly IRateService _rateService;
        public TransactionService(ApplicationDataContext context, IRateService rateService)
        {
            _context = context;
            _rateService = rateService;
        }
        public async Task<Transaction> AddTransactionAsync(TransactionDto transactionDto)
        {

            // call RateService and get the list of rates and currencies
            // get the rate of AMD and user selected currency
            // check if the previous rate is equal to current rate then calculate and save with confirmed status
            // check if the previous rate is not equal to current rate then caluclate save with pending status and ask user to confirm


            var rates = await _rateService.GetAsync();


            if (rates.Rates.ContainsKey(transactionDto.Currency))
            {
                var rateCurrency = rates.Rates[transactionDto.Currency];

            }

            var rateAmd = rates.Rates["AMD"];




            var transaction = new Transaction()
            {
                CreatedDate = transactionDto.CreatedDate,
                ConfirmedDate = transactionDto.ConfirmedDate,
                Currency = transactionDto.Currency,
                CurrencyCode = Flan.CurrencyCodes[transactionDto.Currency],
                CurrencyName = Flan.CurrencyNames[transactionDto.Currency] ,
                ExchangeRate = transactionDto.ExchangeRate,
                Amount = transactionDto.Amount,
                ExchangedAmount = transactionDto.ExchangedAmount,
                Status = transactionDto.Status
            };

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        private double CalculateAmount(string currency, double rateAmd, double rateCurrency, double amount)
        {
            return currency == "EUR" ? amount * rateCurrency : amount * rateAmd / rateCurrency;
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

    public static class Flan
    {
        public static Dictionary<string, string> CurrencyNames { get; set; } = new Dictionary<string, string>() {
            {"AMD", "DRAM"}


        };

        public static Dictionary<string, string> CurrencyCodes { get; set; } = new Dictionary<string, string>() {
            {"AMD", "041"}


        };
    }
}
