using GerenciadorDeTarefas.Models;
using System.Linq;

namespace GerenciadorDeTarefas.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly GerenciadorDeTarefasContext _contexto;
        public UsuarioRepositoryImpl(GerenciadorDeTarefasContext contexto)
        {
            _contexto = contexto;
        }

        public bool ExisteUsuarioPeloEmail(string email)
        {
           return _contexto.Usuario.Any(usuario => usuario.Email.ToLower() == email.ToLower() );
        }

        public void Salvar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }
    }
}
