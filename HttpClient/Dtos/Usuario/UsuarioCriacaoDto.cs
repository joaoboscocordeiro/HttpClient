using System.ComponentModel.DataAnnotations;

namespace HttpClient.Dtos.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "Digite o Usuário!")]
        public string Usuario { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o Sobrenome!")]
        public string Sobrenome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o Email!")]
        public string Email { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Digite a Senha!")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "Confirme a Senha!"), Compare("Senha", ErrorMessage = "As senhas estão divergentes!")]
        public string ConfirmaSenha { get; set; } = string.Empty;
    }
}
