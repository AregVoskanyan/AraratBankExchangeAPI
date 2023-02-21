using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            var rates = await _rateService.GetAsync();


            if (rates.Rates.ContainsKey(transactionDto.Currency))
            {
                var rateCurrency = rates.Rates[transactionDto.Currency];

            }

            var rateAmd = rates.Rates["AMD"];

                var transaction = new Transaction()
                {
                    CreatedDate = transactionDto.CreatedDate,
                    Currency = transactionDto.Currency,
                    CurrencyCode = CurrencyCode.CurrencyCodes[transactionDto.Currency],
                    CurrencyName = CurrencyName.CurrencyNames[transactionDto.Currency],
                    ExchangeRate = transactionDto.ExchangeRate,
                    Amount = transactionDto.Amount,
                    ExchangedAmount = CalculateAmount(transactionDto.Currency, rateAmd, transactionDto.ExchangeRate, transactionDto.Amount),
                };
            if(transactionDto.Currency != transactionDto.CurrencyName
                || transactionDto.Currency != transactionDto.CurrencyCode
                || transactionDto.CurrencyCode != transactionDto.CurrencyName)
            {
                transactionDto.Status = Enums.TransactionStatus.Failed;
                transaction.Status = Enums.TransactionStatus.Failed;
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                return transaction;
            }
            else
            {
                transactionDto.Status = Enums.TransactionStatus.Successful;
                transaction.Status = Enums.TransactionStatus.Successful;
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                return transaction;
            }                
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

        public async Task<Transaction> GetTransactionByIdAsync(Guid transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            return transaction;
        }
    }
}