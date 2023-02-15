using System.ComponentModel.DataAnnotations;

namespace TransactionExchange.Api.Data.Entities
{
    public class TokenRequestModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
