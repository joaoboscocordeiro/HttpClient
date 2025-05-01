using HttpClientWeb.Models;

namespace HttpClientWeb.Services.Sessao
{
    public interface ISessaoInterface
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
