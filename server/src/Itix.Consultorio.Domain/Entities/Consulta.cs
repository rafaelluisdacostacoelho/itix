using System;

namespace Itix.Consultorio.Domain.Entities
{
    public class Consulta
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }

        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
