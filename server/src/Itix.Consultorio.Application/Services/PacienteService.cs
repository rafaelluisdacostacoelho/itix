using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace Itix.Consultorio.Application.Services
{
    public class PacienteService : IPacienteService
    {
        public Guid Create(PacienteRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PacienteResponse> Read()
        {
            throw new NotImplementedException();
        }

        public PacienteResponse Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, PacienteRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
