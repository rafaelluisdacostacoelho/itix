using System;

namespace Itix.Consultorio.Domain.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
