using Dapper;
using Itix.Consultorio.Domain.Entities;
using Itix.Consultorio.Domain.Interfaces;
using Itix.Consultorio.Infrastructure.Context;
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
            Context = new ItixConsultorioContext();
        }

        public int Create(Paciente paciente)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Nome", paciente.Nome);
            parameters.Add("Nascimento", paciente.Nascimento);

            string query = @"
                INSERT INTO [Itix].[Consultorio].[Pacientes] ([Nome], [Nascimento])
                OUTPUT INSERTED.[Id]
                VALUES (@Nome, @Nascimento)";

            return Context.Connection.QuerySingle<int>(query, parameters);
        }

        public IEnumerable<Paciente> Read()
        {
            string query = @"
                SELECT [Id],
                       [Nome],
                       [Nascimento]
                  FROM [Itix].[Consultorio].[Pacientes]
                 ORDER BY [Nome]";

            var pacientes = Context
                .Connection
                .Query<dynamic>(query);

            return pacientes
                .Select(paciente => new Paciente
                {
                    Id = paciente.Id,
                    Nome = paciente.Nome,
                    Nascimento = paciente.Nascimento
                });
        }

        public Paciente Read(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id);

            string query = $@"
                SELECT [Id],
                       [Nome],
                       [Nascimento]
                  FROM [Itix].[Consultorio].[Pacientes]
                 WHERE [Id] = @Id";

            var paciente = Context
                .Connection
                .QuerySingle<dynamic>(query, parameters);

            return new Paciente
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Nascimento = paciente.Nascimento
            };
        }

        public void Update(Paciente paciente)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", paciente.Id);

            List<string> clauses = new List<string>();

            if (!string.IsNullOrWhiteSpace(paciente.Nome))
            {
                clauses.Add("[Nome] = @Nome");
                parameters.Add("Nome", paciente.Nome);
            }

            string query = $@"
                    UPDATE [Itix].[Consultorio].[Pacientes]
                       SET {string.Join(", ", clauses)}
                     WHERE [Id] = @Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id);

            string query = "DELETE FROM [Itix].[Consultorio].[Pacientes] WHERE [Id] = @Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
