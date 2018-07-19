using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace Itix.Consultorio.Application.Interfaces
{
    public interface IConsultaService
    {
        IEnumerable<ConsultaResponse> Read();
        ConsultaResponse Read(Guid id);
        Guid Create(ConsultaRequest request);
        void Update(Guid id, ConsultaRequest request);
        void Delete(Guid id);
    }
}
