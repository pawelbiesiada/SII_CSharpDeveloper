using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using EFTestNET.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFTestNET
{
    //Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=EFTestDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AddUsers();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadKey();
        }

        static void AddUsers()
        {
            using (var dbCtx = new EFTestDbContext())
            {

                try
                {
                    var activeUsers = dbCtx.Users
                        .Where(u => u.IsActive)
                        .GroupBy(u => u.Name)
                        .Select(u => u.Key).ToArray();
                    //select name from users where isactive = 0 group by name 

                    //dbCtx.Users.RemoveRange(dbCtx.Users);
                    //dbCtx.Groups.RemoveRange(dbCtx.Groups);
                    //dbCtx.UserGroups.RemoveRange(dbCtx.UserGroups);

                    var userId = dbCtx.Users.Max(el => el.Id);
                    var groupId = dbCtx.Groups.Max(el => el.Id);

                    var user = dbCtx.Users.Add(new User { Name = "John", Password = "Password", IsActive = true });

                    EntityEntry<Group> group = null;
                    if (!dbCtx.Groups.Any(el => el.Name == "Administrator"))
                    {
                        group = dbCtx.Groups.Add(new Group {Id = groupId + 1,  Name = "Administrator" });
                    }
                    //var users = dbCtx.Users.Include(e => e.Name).ToList();
                    dbCtx.SaveChanges();

                    if (group != null)
                    {
                        var userGroupId = dbCtx.UserGroups.Max(el => el.Id);
                        var userGroup = dbCtx.UserGroups.Add(new UserGroup() { Id = userGroupId + 1, GroupId = group.Entity.Id, UserId = user.Entity.Id });

                        dbCtx.SaveChanges();

                        var c = user.Entity.UserGroups.Count;
                    }
                    var count = dbCtx.Users.First().UserGroups.Count;

                    dbCtx.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
