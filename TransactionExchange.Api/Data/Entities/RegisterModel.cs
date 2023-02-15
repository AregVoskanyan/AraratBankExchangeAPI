using System.ComponentModel.DataAnnotations;

namespace TransactionExchange.Api.Data.Entities
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string EmailAdress { get; set; }

        [Required]
        public string Username { get; set; }
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
