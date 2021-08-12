using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class AutenticacaoModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}