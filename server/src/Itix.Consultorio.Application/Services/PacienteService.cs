using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using Itix.Consultorio.Domain.Entities;
using Itix.Consultorio.Domain.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Itix.Consultorio.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }

        public int Create(PacienteRequest request)
        {
            return pacienteRepository.Create(new Paciente
            {
                Nome = request.Nome,
                Nascimento = request.Nascimento
            });
        }

        public IEnumerable<PacienteResponse> Read()
        {
            return pacienteRepository
                .Read()
                .Select(paciente => new PacienteResponse
                {
                    Id = paciente.Id,
                    Nome = paciente.Nome,
                    Nascimento = paciente.Nascimento
                });
        }

        public PacienteResponse Read(int id)
        {
            dynamic paciente = pacienteRepository.Read(id);

            return new PacienteResponse
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Nascimento = paciente.Nascimento
            };
        }

        public void Update(int id, PacienteRequest request)
        {
            pacienteRepository.Update(new Paciente
            {
                Id = id,
                Nome = request.Nome,
                Nascimento = request.Nascimento
            });
        }

        public void Delete(int id)
        {
            pacienteRepository.Delete(id);
        }
    }
}
