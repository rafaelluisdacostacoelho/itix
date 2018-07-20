using Itix.Consultorio.Application.Interfaces;
using Itix.Consultorio.Application.Models.Requests;
using Itix.Consultorio.Application.Models.Responses;
using Itix.Consultorio.Domain.Entities;
using Itix.Consultorio.Domain.InterfacesPaciente;
using System.Collections.Generic;
using System.Linq;

namespace Itix.Consultorio.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            this.consultaRepository = consultaRepository;
        }

        public int Create(ConsultaRequest consulta)
        {
            return consultaRepository.Create(new Consulta
            {
                Observacoes = consulta.Observacoes,
                DataInicial = consulta.DataInicial,
                DataFinal = consulta.DataFinal,
                PacienteId = consulta.PacienteId
            });
        }

        public IEnumerable<ConsultaResponse> Read()
        {
            return consultaRepository
                .Read()
                .Select(consulta => new ConsultaResponse
                {
                    Id = consulta.Id,
                    Observacoes = consulta.Observacoes,
                    DataInicial = consulta.DataInicial,
                    DataFinal = consulta.DataFinal
                });
        }

        public ConsultaResponse Read(int id)
        {
            dynamic consulta = consultaRepository.Read(id);

            return new ConsultaResponse
            {
                Id = consulta.Id,
                Observacoes = consulta.Observacoes,
                DataInicial = consulta.DataInicial,
                DataFinal = consulta.DataFinal,
                PacienteId = consulta.PacienteId
            };
        }

        public void Update(int id, ConsultaRequest consulta)
        {
            consultaRepository.Update(new Consulta
            {
                Id = id,
                Observacoes = consulta.Observacoes,
                DataInicial = consulta.DataInicial,
                DataFinal = consulta.DataFinal
            });
        }

        public void Delete(int id)
        {
            consultaRepository.Delete(id);
        }
    }
}
