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

        public void Create(Paciente paciente)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Nome", paciente.Nome);
            parameters.Add("Nascimento", paciente.Nascimento);

            const string query = @"
                INSERT INTO [Itix].[Consultorio].[Pacientes]
                    ([Nome], [Nascimento])
                VALUES
                    (@Nome, @Nascimento)";

            Context.Connection.Execute(query, parameters);
        }

        public IEnumerable<Paciente> Read()
        {
            const string query = @"
                SELECT [Id],
                       [Nome],
                       [Nascimento]
                  FROM [Itix].[Consultorio].[Pacientes]
                 ORDER BY [Nome]";

            var pacientes = Context.Connection.Query<dynamic>(query);

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

            var paciente = Context.Connection.QuerySingle<dynamic>(query, parameters);

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

            parameters.Add("Nome", paciente.Nome);
            parameters.Add("Nascimento", paciente.Nascimento);

            const string query = @"
                    UPDATE [Itix].[Consultorio].[Pacientes]
                       SET [Nome] = @Nome,
                           [Nascimento] = @Nascimento
                     WHERE [Id] = @Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id);

            const string query = "DELETE FROM [Itix].[Consultorio].[Pacientes] WHERE [Id] = @Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
