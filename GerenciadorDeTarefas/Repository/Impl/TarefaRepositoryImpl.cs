using GerenciadorDeTarefas.Models;
using System.Linq;

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

        public Tarefa GetById(int idTarefa)
        {
            return _contexto.Tarefa.FirstOrDefault(tarefa => tarefa.Id == idTarefa);
        }

        public void RemoverTarefa(Tarefa tarefa)
        {
            _contexto.Tarefa.Remove(tarefa);
            _contexto.SaveChanges();
        }
    }
}
