using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class RegistroModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Documento { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Role { get; set; } = "cliente";
    }
}