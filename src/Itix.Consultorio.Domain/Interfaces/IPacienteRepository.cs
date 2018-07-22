using Itix.Consultorio.Domain.Entities;
using System.Collections.Generic;

namespace Itix.Consultorio.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        void Create(Paciente paciente);

        IEnumerable<Paciente> Read();

        Paciente Read(int id);

        void Update(Paciente paciente);

        void Delete(int id);
    }
}
