﻿using Itix.Consultorio.Application.Interfaces;
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
        private readonly IPacienteService pacienteService;

        public ConsultaService(IConsultaRepository consultaRepository, IPacienteService pacienteService)
        {
            this.consultaRepository = consultaRepository;
            this.pacienteService = pacienteService;
        }

        public void Create(ConsultaRequest request)
        {
            Consulta consulta = new Consulta(consultaRepository)
            {
                Observacoes = request.Observacoes,
                DataInicial = request.DataInicial,
                DataFinal = request.DataFinal,
                PacienteId = request.PacienteId
            };

            consultaRepository.Create(consulta);
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
                    DataFinal = consulta.DataFinal,
                    PacienteId = consulta.PacienteId,
                    Paciente = pacienteService.Read(consulta.PacienteId)
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

        public void Update(int id, ConsultaRequest request)
        {
            Consulta consulta = new Consulta(consultaRepository)
            {
                Id = id,
                Observacoes = request.Observacoes,
                DataInicial = request.DataInicial,
                DataFinal = request.DataFinal,
                PacienteId = request.PacienteId
            };

            consultaRepository.Update(consulta);
        }

        public void Delete(int id)
        {
            consultaRepository.Delete(id);
        }
    }
}
