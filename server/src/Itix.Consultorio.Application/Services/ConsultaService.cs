using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace Itix.Consultorio.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        public Guid Create(ConsultaRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsultaResponse> Read()
        {
            throw new NotImplementedException();
        }

        public ConsultaResponse Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, ConsultaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
