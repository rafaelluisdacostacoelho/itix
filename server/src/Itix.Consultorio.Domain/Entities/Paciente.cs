using System;

namespace Itix.Consultorio.Domain.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
