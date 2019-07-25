using System.Data;
using System.Data.SqlClient;
using Samtel.Application.BusinessService.Base;
using System.Configuration;

namespace Samtel.Persistence.Dapper
{
    public class DapperContext : IContext
    {
        private IDbConnection _connection;
        private readonly string _connectionString;
        public IDbTransaction CurrentTransaction { get; set; }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public DapperContext()
        {
           _connectionString = ConfigurationManager.ConnectionStrings["SGE"].ConnectionString;
        }

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
