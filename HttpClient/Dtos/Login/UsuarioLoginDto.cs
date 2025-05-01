using System.ComponentModel.DataAnnotations;

namespace HttpClient.Dtos.Login
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite a senha!")]
        public string Senha { get; set; } = string.Empty;
    }
}
