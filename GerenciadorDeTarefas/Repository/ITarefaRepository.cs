using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repository
{
    public interface ITarefaRepository
    {
        public void AdicionarTarefa(Tarefa tarefa);
    }
}
