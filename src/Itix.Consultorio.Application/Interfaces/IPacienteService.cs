using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using System.Collections.Generic;

namespace Itix.Consultorio.Application.Interfaces
{
    public interface IPacienteService
    {
        IEnumerable<PacienteResponse> Read();
        PacienteResponse Read(int id);
        void Create(PacienteRequest request);
        void Update(int id, PacienteRequest request);
        void Delete(int id);
    }
}
