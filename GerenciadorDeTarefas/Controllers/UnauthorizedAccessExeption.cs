using System;
using System.Runtime.Serialization;

namespace GerenciadorDeTarefas.Controllers
{
    [Serializable]
    internal class UnauthorizedAccessExeption : Exception
    {
        public UnauthorizedAccessExeption()
        {
        }

        public UnauthorizedAccessExeption(string message) : base(message)
        {
        }

        public UnauthorizedAccessExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedAccessExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}