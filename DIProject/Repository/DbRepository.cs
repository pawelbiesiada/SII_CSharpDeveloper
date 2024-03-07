using DIProject.Model;
using System.Data.Common;
using System.Data.SqlClient;

namespace DIProject.Repository
{
    public class DbRepository : IRepository
    {
        private readonly string _connStr = "";

        public int ExecuteNonQueryCommand(string command)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = command;
                return cmd.ExecuteNonQuery();
            }
        }

        public User? GetUserCommand(int id)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM Users WHERE Id = {id}";
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var user = new User
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        IsActive = reader.GetBoolean(2),
                        Password = reader.GetString(3),
                    };

                    return user;
                }
            }
            return null;
        }
    }
}
