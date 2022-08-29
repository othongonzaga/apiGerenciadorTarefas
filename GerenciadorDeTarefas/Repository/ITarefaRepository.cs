using GerenciadorDeTarefas.Enums;
using GerenciadorDeTarefas.Models;
using System;
using System.Collections.Generic;

namespace GerenciadorDeTarefas.Repository
{
    public interface ITarefaRepository
    {
        public void AdicionarTarefa(Tarefa tarefa);
        Tarefa GetById(int idTarefa);
        public void RemoverTarefa(Tarefa tarefa);
        void AtualizarTarefa(Tarefa tarefa);
        List<Tarefa> BuscarTarefas(int idUsuario, DateTime? periodoDe, DateTime? periodoAte, StatusTarefaEnum status);
    }
}
