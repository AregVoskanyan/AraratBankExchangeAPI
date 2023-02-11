namespace TransactionExchange.Api.Enums
{
    public enum TransactionStatus : byte
    {
        Created, 
        Confirmed,
        ApprovementRequired,
        Failed
    }    
}
