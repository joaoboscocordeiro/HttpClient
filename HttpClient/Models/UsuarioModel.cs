namespace HttpClientWeb.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public byte[] senhaSalt { get; set; }
        public byte[] senhaHash { get; set; }
    }
}
