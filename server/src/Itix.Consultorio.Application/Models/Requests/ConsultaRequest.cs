using System;

namespace Itix.Consultorio.Application.Models.Requests
{
    public class ConsultaRequest
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Observacoes { get; set; }
    }
}
