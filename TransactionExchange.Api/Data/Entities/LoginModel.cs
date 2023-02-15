using System.ComponentModel.DataAnnotations;

namespace TransactionExchange.Api.Data.Entities
{
    public class LoginModel
    {
        [Required]
        public string EmailAdress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
