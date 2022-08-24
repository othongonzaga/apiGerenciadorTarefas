using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repository.Impl
{
    public class TarefaRepositoryImpl : ITarefaRepository
    {
        private readonly GerenciadorDeTarefasContext _contexto;

        public TarefaRepositoryImpl(GerenciadorDeTarefasContext contexto)
        {
            _contexto = contexto;
        }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            _contexto.Tarefa.Add(tarefa);
            _contexto.SaveChanges();
        }
    }
}
