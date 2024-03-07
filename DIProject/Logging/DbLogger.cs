using System.Data.SqlClient;

namespace DIProject.Logging
{
    public class DbLogger : ILogger
    {
        private readonly string _connStr;
        public DbLogger(string connectionString)
        {
            _connStr = connectionString;
        }

        public void LogDebug(string msg)
        {
            using(var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO Logs VALUES('Debug', '{msg}')";
                cmd.ExecuteNonQuery();
            }
        }

        public void LogError(string msg)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO Logs VALUES('Error', '{msg}')";
                cmd.ExecuteNonQuery();
            }
        }

        public void LogWarning(string msg)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO Logs VALUES('Warning', '{msg}')";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
