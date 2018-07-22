using Dapper;
using Itix.Consultorio.Domain.Entities;
using Itix.Consultorio.Domain.InterfacesPaciente;
using Itix.Consultorio.Infrastructure.Context;
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
            Context = new ItixConsultorioContext();
        }

        public void Create(Consulta consulta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Observacoes", consulta.Observacoes);
            parameters.Add("DataInicial", consulta.DataInicial);
            parameters.Add("DataFinal", consulta.DataFinal);
            parameters.Add("PacienteId", consulta.PacienteId);

            const string query = @"
                INSERT INTO [Itix].[Consultorio].[Consultas]
                    ([Observacoes], [DataInicial], [DataFinal], [PacienteId])
                VALUES
                    (@Observacoes, @DataInicial, @DataFinal, @PacienteId)";

            Context.Connection.Execute(query, parameters);
        }

        public IEnumerable<Consulta> Read()
        {
            const string query = @"
                SELECT [Id],
                       [Observacoes],
                       [DataInicial],
                       [DataFinal],
                       [PacienteId]
                  FROM [Itix].[Consultorio].[Consultas]
                 ORDER BY [DataInicial]";

            var consultas = Context
                .Connection
                .Query<dynamic>(query);

            return consultas
                .Select(consulta => new Consulta
                {
                    Id = consulta.Id,
                    DataInicial = consulta.DataInicial,
                    DataFinal = consulta.DataFinal,
                    Observacoes = consulta.Observacoes,
                    PacienteId = consulta.PacienteId
                });
        }

        public Consulta Read(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id);

            const string query = @"
                SELECT [Id],
                       [Observacoes],
                       [DataInicial],
                       [DataFinal],
                       [PacienteId]
                  FROM [Itix].[Consultorio].[Consultas]
                 WHERE Id = @Id";

            var consulta = Context
                .Connection
                .QuerySingleOrDefault<dynamic>(query, parameters);

            return new Consulta
            {
                Id = consulta.Id,
                Observacoes = consulta.Observacoes,
                DataInicial = consulta.DataInicial,
                DataFinal = consulta.DataFinal,
                PacienteId = consulta.PacienteId
            };
        }

        public void Update(Consulta consulta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", consulta.Id);

            parameters.Add("Observacoes", consulta.Observacoes);
            parameters.Add("DataInicial", consulta.DataInicial);
            parameters.Add("DataFinal", consulta.DataFinal);
            parameters.Add("PacienteId", consulta.PacienteId);

            const string query = @"
                UPDATE [Itix].[Consultorio].[Consultas]
                    SET [PacienteId] = @PacienteId,
                        [DataFinal] = @DataFinal,
                        [DataInicial] = @DataInicial,
                        [Observacoes] = @Observacoes
                    WHERE [Id] = @Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id);

            const string query = "DELETE FROM [Itix].[Consultorio].[Consultas] WHERE [Id] = @Id";

            Context.Connection.Execute(query, parameters);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
