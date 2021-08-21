namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Documento { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Role { get; set; }
    }
}