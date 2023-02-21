using System.Collections.Generic;

namespace TransactionExchange.Api.Data.Entities
{
    public static class CurrencyName
    {
        public static Dictionary<string, string> CurrencyNames { get; set; } = new Dictionary<string, string>() {
            {"AMD", "Հայկական դրամ"},
            {"USD", "ԱՄՆ դոլլար"},
            {"GBP", "Անգլ․ ֆունտ ստեռլինգ"},
            {"CHF", "Շվեյցարական ֆրանկ"},
            {"SEK", "Շվեդական կրոն"},
            {"NOK", "Նորվեգական կրոն"},
            {"CAD", "Կանադական դոլլար"},
            {"JPY", "Ճապոնական իեն"},
            {"GEL", "Վրացական լարի"},
            {"AUD", "Ավստրալիական դոլլար"},
            {"IRR", "Իրանական ռիալ"},
            {"EUR", "ԵՎՐՈ"},
            {"RUB", "Ռուսական ռուբլի"},
            {"UAH", "ՈՒկրաինական գրիվնա"},
            {"AED", "ՄԱԷ դիրխամ"},
            {"HKD", "Հոնգկոնգյան դոլլար"},
            {"CNY", "Չինական յուան"},
            {"CZK", "Չեխական կրոն"},
            {"BYN", "Բելոռուսական ռուբլի"},
            {"KZT", "Ղազախական տենգե"},
            {"KGS", "Ղրղզական սոմ"}
        };
    }
}
