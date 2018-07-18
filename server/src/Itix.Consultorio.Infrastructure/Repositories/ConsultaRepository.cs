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
    public class ConsultaRepository : IConsultaRepository
    {
        protected readonly ItixConsultorioContext Context;

        public ConsultaRepository()
        {
            this.Context = new ItixConsultorioContext();
        }

        public int Create(Consulta consulta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", consulta.Id.ToByteArray());
            parameters.Add("Descricao", consulta.Descricao);
            parameters.Add("DataDeInicio", consulta.DataDeInicio);
            parameters.Add("DataDeFim", consulta.DataDeFim);
            parameters.Add("PacienteId", consulta.PacienteId.ToByteArray());

            string query = @"
                INSERT INTO Itix.Consultas
                    (Id, Description, DataDeInicio, DataDeFim, PacienteId)
                VALUES
                    (?Id, ?Description, ?DataDeInicio, ?DataDeFim, ?PacienteId)";

            return Context.Connection.Execute(query, parameters);
        }

        public IEnumerable<Consulta> Read()
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("LimitPerPage", PageConfiguration.LimitPerPage);

            string query = @"
                SELECT Id,
                       Descricao,
                       DataDeInicio,
                       DataDeFim,
                       PacienteId
                  FROM Itix.Consultas
                 ORDER BY DataDeInicio LIMIT ?LimitPerPage";

            var consultas = Context
                .Connection
                .Query<dynamic>(query, parameters)
                .Select(consulta => new Consulta
                {
                    Id = new Guid(consulta.Id),
                    Descricao = consulta.Descricao,
                    PacienteId = new Guid(consulta.PacienteId)
                });

            return consultas;
        }

        public void Update(Consulta consulta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", consulta.Id.ToByteArray());

            List<string> clauses = new List<string>();

            if (!string.IsNullOrWhiteSpace(consulta.Descricao))
            {
                clauses.Add("Descricao = ?Descricao");
                parameters.Add("Descricao", consulta.Descricao);
            }
            if (consulta.PacienteId != Guid.Empty)
            {
                clauses.Add("PacienteId = ?PacienteId");
                parameters.Add("PacienteId", consulta.PacienteId.ToByteArray());
            }

            string query = $@"
                    UPDATE Itix.Consultas
                       SET {string.Join(", ", clauses)}
                     WHERE Id = ?Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Delete(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id.ToByteArray());

            string query = "DELETE FROM Itix.Consultas WHERE Id = ?Id";

            Context.Connection.Execute(query, parameters);
        }

        public Consulta GetById(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id.ToByteArray());

            string query = $@"
                SELECT Id,
                       Description,
                       DataDeInicio,
                       DataDeFim,
                       PacienteId
                  FROM Itix.Consultas
                 WHERE Id = ?Id";

            var consulta = Context
                .Connection
                .QuerySingleOrDefault<dynamic>(query, parameters);

            return new Consulta
            {
                Id = new Guid(consulta.Id),
                Descricao = consulta.Description,
                DataDeInicio = consulta.DataDeInicio,
                DataDeFim = consulta.DataDeFim,
                PacienteId = new Guid(consulta.SupplierId)
            };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
