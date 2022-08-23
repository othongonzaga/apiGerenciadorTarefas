using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repository
{
    public interface IUsuarioRepository
    {
        public void Salvar(Usuario usuario);
        bool ExisteUsuarioPeloEmail(string email);
    }
}
