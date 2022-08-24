using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repository
{
    public interface ITarefaRepository
    {
        public void AdicionarTarefa(Tarefa tarefa);
        Tarefa GetById(int idTarefa);
        public void RemoverTarefa(Tarefa tarefa);
    }
}
