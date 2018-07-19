using System;

namespace Itix.Consultorio.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
