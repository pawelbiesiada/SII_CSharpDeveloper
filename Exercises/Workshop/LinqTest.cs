using CSharpConsole.Exercises;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Workshop
{

    class UserComparerByName : IEqualityComparer<User>
    {
        public bool Equals(User? x, User? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] User obj)
        {
            throw new NotImplementedException();
        }
    }

    internal class LinqTest
    {

        public void Test()
        {
            var users = CreateCollection.GetUsers();
            users = users.Where(u => u != null);

            //has any element
            var hasAnyElement = users.Any();
            
            //has any active user
            //var hasAnyactive = users.Any(IsActive); // =>
           // var hasAnyactive = users.Any(u => u.IsActive);
            //non-null users count
            var nonNullUsersCount = users.Where(u => u != null).Count();

            //users starts with "M"
            var mUsers = users.Where(u => u.Name.StartsWith("M"));

            // TOP 5 users by name
            var top5UsersByName = users.OrderBy(u => u.Name).Take(5);

            // second TOP 5 users
            var itemsPerPage = 5;
            var pageNumber = 5;
            var secondPage = users.OrderBy(u => u.Name).Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage);

            //Get distinct names
           // var distinctNames = users.Distinct(new UserComparerByName());
            //foreach (var item in distinctNames)
            //{
            //    Console.WriteLine(item);
            //}

            var dist = users.DistinctBy(u => u.Name);
            foreach (var item in dist)
            {
                Console.WriteLine(item.Name);
            }

            //var Get duplicated names
            var dups = users.GroupBy(u => u.Name).Where(u => u.Count() > 1).Select(g => g.Key).ToArray();

            // duplicated users
            var dupUsers = users.GroupBy(u => u.Name).Where(u => u.Count() > 1).ToArray();

            foreach (var group in dupUsers)
            {
                foreach (var us in group)
                {
                    Console.WriteLine(us.Name);
                }
            }

            var dupUsersArr = users.GroupBy(u => u.Name).Where(u => u.Count() > 1).SelectMany(u => u).ToArray();
            foreach (var item in dupUsersArr)
            {
                Console.WriteLine(item.Name);
            }

            //Get superUSers
            var linq9 = users.OfType<SuperUser>();
            // get active admins
            var linq10 = users.OfType<SuperUser>().Where(s => s.IsAdmin && s.IsActive);
            //Get fitrs admin
            var linq11 = users.OfType<SuperUser>().FirstOrDefault(s => s.IsAdmin);
            //Get Dictionary with suer names and their count by name
            var linq12 = users.GroupBy(user => user.Name).ToDictionary(group => group.Key, group => group.Count());


        }


        private bool IsActive(User user)
        { return user.IsActive; }
    }
}
