// See https://aka.ms/new-console-template for more information
using DIProject.UserManager;
using DIProject.Logging;
using DIProject.Model;
using DIProject.Repository;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

//var userManager = new UserManager(new DbRepository(), new DbLogger("SomeConnectionString")) ;

var container = new UnityContainer();


container.RegisterType<IUserManager, UserManager>();


//container.RegisterType<ILogger, DbLogger>(new ContainerControlledLifetimeManager(), new InjectionConstructor("SomeConnStr"));

container.RegisterType<ILogger, ConsoleLogger>();
container.RegisterType<IRepository, DbRepository>();
//container.RegisterInstance<DbRepository>(new DbRepository());


var repo = container.Resolve<DbRepository>();

var userManager = container.Resolve<IUserManager>();

TestUserManager(userManager);

Console.ReadKey();

Console.WriteLine();


static void TestUserManager(IUserManager userManager)
{
    userManager.AddUser(new User { Id = 2, Name = "John", IsActive = true, Password = "SecurePass" }) ;
    var user = userManager.GetUser(2);

}
