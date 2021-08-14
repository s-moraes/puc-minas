namespace WebApi.Entities
{
    public class Deposito
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public string Remetente { get; set; }
        public string Email { get; set; }
        public string EnderecoOrigem { get; set; }
        public string CepOrigem { get; set; }
        public string CidadeOrigem { get; set; }
        public string EstadoOrigem { get; set; }
        public string Peso { get; set; }
        public string Tamanho { get; set; }
        public string Destinatario { get; set; }
        public string EnderecoDestino { get; set; }
        public string CepDestino { get; set; }
        public string CidadeDestino { get; set; }
        public string EstadoDestino { get; set; }
    }
}