using System;

namespace TransactionExchange.Api.Data.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double ExchangeRate { get; set; }
        public double Amount { get; set; }
        public double ExchangedAmount { get; set; }
        public byte Status { get; set; } 
    }
}
