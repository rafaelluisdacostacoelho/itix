using System;

namespace Itix.Consultorio.Application.Models.Responses
{
    public class ConsultaResponse
    {
        public int Id { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int PacienteId { get; set; }
        public PacienteResponse Paciente { get; set; }
    }
}
