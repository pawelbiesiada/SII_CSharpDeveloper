using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace Exercises.Workshop
{
    internal class SQLCommand
    {
        private readonly string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFTestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        public void Test()
        {
            var query = "SELECT u.Name as UserName, g.Name as GroupName FROM Users u JOIN UserGroups ug ON u.Id = ug.UserId JOIN Groups g ON g.Id = ug.GroupId";

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText = query;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString("UserName")} : {reader.GetString("GroupName")}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OracleTest()
        {
            var query = "SELECT u.Name as UserName, g.Name as GroupName FROM Users u JOIN UserGroups ug ON u.Id = ug.UserId JOIN Groups g ON g.Id = ug.GroupId";

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText = query;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString("UserName")} : {reader.GetString("GroupName")}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
