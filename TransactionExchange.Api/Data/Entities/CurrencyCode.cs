using System.Collections.Generic;

namespace TransactionExchange.Api.Data.Entities
{
    public static class CurrencyCode
    {
        public static Dictionary<string, string> CurrencyCodes { get; set; } = new Dictionary<string, string>() {
            {"AMD", "041"},
            {"USD", "001"},
            {"GBP", "003"},
            {"CHF", "006"},
            {"SEK", "007"},
            {"NOK", "017"},
            {"CAD", "022"},
            {"JPY", "024"},
            {"GEL", "031"},
            {"AUD", "035"},
            {"IRR", "044"},
            {"EUR", "049"},
            {"RUB", "058"},
            {"UAH", "059"},
            {"AED", "081"},
            {"HKD", "090"},
            {"CNY", "091"},
            {"CZK", "092"},
            {"BYN", "094"},
            {"KZT", "095"},
            {"KGS", "096"}
        };
    }
}
