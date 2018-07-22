using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using System.Collections.Generic;

namespace Itix.Consultorio.Application.Interfaces
{
    public interface IConsultaService
    {
        IEnumerable<ConsultaResponse> Read();
        ConsultaResponse Read(int id);
        void Create(ConsultaRequest request);
        void Update(int id, ConsultaRequest request);
        void Delete(int id);
    }
}
