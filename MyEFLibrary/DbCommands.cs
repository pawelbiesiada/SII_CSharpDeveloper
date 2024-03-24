using MyEFLibrary.Models;

namespace MyEFLibrary
{
    public class DbCommands
    {
        public void Execute()
        {
            using (var ctx = new EftestDbContext())
            {
                // Add new group "PowerUser"
                var groups = ctx.Groups;
                groups.Add(new Group() { Name = "PowerUser" });

                //Remove non active users
                var users = ctx.Users;
                users.RemoveRange(users.Where(u => !u.IsActive));

                ctx.SaveChanges();

                //Get all users with their groups
                var usersWithGroups = ctx.Users
                    .SelectMany(u => u.UserGroups.Select(ug => new { UserName = u.Name, GroupName = ug.Group.Name }))
                    .ToArray();

                foreach (var userGroup in usersWithGroups)
                {
                    Console.WriteLine(userGroup.UserName + userGroup.GroupName);
                }

                //get all users with their groups - select
                var usersWithGroupsSelect = ctx.Users
                    .Select(u => u.UserGroups.Select(ug => new { UserName = u.Name, GroupName = ug.Group.Name }).ToList())
                    .ToList();
                
                foreach (var user in usersWithGroupsSelect)
                {
                    foreach (var userGroup in user)
                    {
                        Console.WriteLine(userGroup.UserName + userGroup.GroupName);
                    }
                }



                //Get all groups for a single user
                var userGroups = ctx.Users
                    .FirstOrDefault(u => u.Id == 13)
                        ?.UserGroups.Select(ug => ug.Group.Name)
                    .ToArray() ?? new string[0];



            }
        }
    }
}
