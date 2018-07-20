using System;

namespace Itix.Consultorio.Application.Models.Requests
{
    public class PacienteRequest
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
