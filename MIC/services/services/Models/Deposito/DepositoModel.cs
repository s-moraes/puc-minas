using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Deposito
{
    public class Deposito
    {
        [Required]
        public int Cliente { get; set; }

        [Required]
        public string Remetente { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string EnderecoOrigem { get; set; }

        [Required]
        public string CepOrigem { get; set; }

        [Required]
        public string CidadeOrigem { get; set; }

        [Required]
        public string EstadoOrigem { get; set; }

        [Required]
        public string Peso { get; set; }

        [Required]
        public string Tamanho { get; set; }

        [Required]
        public string Destinatario { get; set; }

        [Required]
        public string EnderecoDestino { get; set; }

        [Required]
        public string CepDestino { get; set; }

        [Required]
        public string CidadeDestino { get; set; }

        [Required]
        public string EstadoDestino { get; set; }
    }
}