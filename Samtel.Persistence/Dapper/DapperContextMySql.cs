using System.Data;
using MySql.Data;
using Samtel.Application.BusinessService.Base;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Samtel.Persistence.Dapper
{
    public class DapperContextMySql : IContext
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
                    _connection = new MySqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public DapperContextMySql()
        {
           _connectionString = ConfigurationManager.ConnectionStrings["SGE_MySql"].ConnectionString;
        }

        public DapperContextMySql(string connectionString)
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
