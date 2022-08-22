using System.Collections.Generic;

namespace GerenciadorDeTarefas.Dtos
{
    public class ErroRespostaDto
    {
        public string Erro { get; set; }
        public int Status { get; set; }
        public List<string> Erros { get; set; }
    }
}
