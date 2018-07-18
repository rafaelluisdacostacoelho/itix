using Dapper;
using Itix.Consultorio.Domain.Entities;
using Itix.Consultorio.Domain.Interfaces;
using Itix.Consultorio.Infrastructure.Context;
using Itix.Domain.Utilities.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itix.Consultorio.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        protected readonly ItixConsultorioContext Context;

        public PacienteRepository()
        {
            this.Context = new ItixConsultorioContext();
        }

        public int Create(Paciente paciente)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", paciente.Id.ToByteArray());
            parameters.Add("Nome", paciente.Nome);
            parameters.Add("Nascimento", paciente.Nascimento);

            string query = @"
                INSERT INTO Itix.Pacientes
                    (Id, Nome, Nascimento)
                VALUES
                    (?Id, ?Nome, ?Nascimento)";

            return Context.Connection.Execute(query, parameters);
        }

        public IEnumerable<Paciente> Read()
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("LimitPerPage", PageConfiguration.LimitPerPage);

            string query = @"
                SELECT Id,
                       Descricao,
                       DataDeInicio,
                       DataDeFim,
                       PacienteId
                  FROM Itix.Pacientes
                 ORDER BY DataDeInicio LIMIT ?LimitPerPage";

            var pacientes = Context
                .Connection
                .Query<dynamic>(query, parameters)
                .Select(paciente => new Paciente
                {
                    Id = new Guid(paciente.Id),
                    Nome = paciente.Nome
                });

            return pacientes;
        }

        public void Update(Paciente paciente)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", paciente.Id.ToByteArray());

            List<string> clauses = new List<string>();

            if (!string.IsNullOrWhiteSpace(paciente.Nome))
            {
                clauses.Add("Nome = ?Nome");
                parameters.Add("Nome", paciente.Nome);
            }

            string query = $@"
                    UPDATE Itix.Pacientes
                       SET {string.Join(", ", clauses)}
                     WHERE Id = ?Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Delete(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id.ToByteArray());

            string query = "DELETE FROM Itix.Pacientes WHERE Id = ?Id";

            Context.Connection.Execute(query, parameters);
        }

        public Paciente GetById(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id.ToByteArray());

            string query = $@"
                SELECT Id,
                       Description,
                       DataDeInicio,
                       DataDeFim,
                       PacienteId
                  FROM Itix.Pacientes
                 WHERE Id = ?Id";

            var paciente = Context
                .Connection
                .QuerySingleOrDefault<dynamic>(query, parameters);

            return new Paciente
            {
                Id = new Guid(paciente.Id),
                Nome = paciente.Nome
            };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
