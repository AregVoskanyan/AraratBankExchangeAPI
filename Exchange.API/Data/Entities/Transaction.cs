using Exchange.API.Helpers.Enums;
using System;

namespace Exchange.API.Data.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ConfirmedAt { get; set; }
        public string Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double Amount { get; set; }
        public double ExchangedAmount { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
