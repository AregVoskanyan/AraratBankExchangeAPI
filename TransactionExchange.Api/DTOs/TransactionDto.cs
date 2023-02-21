using System;
using TransactionExchange.Api.Enums;

namespace TransactionExchange.Api.DTOs
{
    public class TransactionDto
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double ExchangeRate { get; set; }
        public double Amount { get; set; }
        public double ExchangedAmount { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
