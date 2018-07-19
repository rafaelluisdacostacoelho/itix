using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace Itix.Consultorio.Application.Interfaces
{
    public interface IPacienteService
    {
        IEnumerable<PacienteResponse> Read();
        PacienteResponse Read(Guid id);
        Guid Create(PacienteRequest request);
        void Update(Guid id, PacienteRequest request);
        void Delete(Guid id);
    }
}
