using System;
using System.Data;
using System.Data.SqlClient;

namespace Itix.Consultorio.Infrastructure.Context
{
    public class ItixConsultorioContext : IDisposable
    {
        private readonly string connectionString = @"Data Source=PC-RAFAEL;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";

        public IDbConnection Connection { get; }

        public ItixConsultorioContext()
        {
            try
            {
                Connection = new SqlConnection(connectionString);
                Connection.Open();
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                    Connection.Dispose();
                }

                disposed = true;
            }
        }

        ~ItixConsultorioContext()
        {
            Dispose(false);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}
