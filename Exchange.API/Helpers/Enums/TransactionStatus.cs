using System;

namespace Exchange.API.Helpers.Enums
{
    public enum TransactionStatus : byte
    {
        Created,
        Confirmed,
        ApprovementRequired,
        Failed
    }
}
