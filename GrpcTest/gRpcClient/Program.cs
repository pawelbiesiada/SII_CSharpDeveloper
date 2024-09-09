// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcService;


using var channel = GrpcChannel.ForAddress("https://localhost:7214");
var greeter = new UserManager.UserManagerClient(channel);

var response = greeter.GetUser(new UserRequest {Name = "John", UserId= 2 });

Console.WriteLine($"Message: {response.Message}\tId:{response.UserId}\tIsActive:{response.IsActive}");


Console.ReadLine();