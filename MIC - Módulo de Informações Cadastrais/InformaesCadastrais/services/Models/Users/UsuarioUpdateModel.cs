namespace WebApi.Models.Users
{
  public class UsuarioUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Documento { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Role { get; set; }
    }
}