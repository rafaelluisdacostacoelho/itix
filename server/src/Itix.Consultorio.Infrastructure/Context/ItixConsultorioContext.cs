using System;
using System.Data;
using System.Data.SqlClient;

namespace Itix.Consultorio.Infrastructure.Context
{
    public class ItixConsultorioContext : IDisposable
    {
        private readonly string server = "127.0.0.1";
        private readonly string database = "Itix";
        private readonly string password = "itix";
        private readonly string user = "root";
        private readonly string port = "3306";

        public IDbConnection Connection { get; }

        public ItixConsultorioContext()
        {
            try
            {
                Connection = new SqlConnection($"Server={server};Database={database};User ID={user};Password={password};Port={port};");
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
