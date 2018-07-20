using System;

namespace Itix.Consultorio.Application.Models.Responses
{
    public class PacienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
