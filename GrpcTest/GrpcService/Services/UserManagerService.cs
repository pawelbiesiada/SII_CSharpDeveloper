using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class UserManagerService : UserManager.UserManagerBase
    {
        private readonly ILogger<UserManagerService> _logger;
        public UserManagerService(ILogger<UserManagerService> logger)
        {
            _logger = logger;
        }

        public override Task<UserReply> GetUser(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserReply
            {
                Message = "Hello " + request.Name,
                UserId = request.UserId,
                IsActive = true
            });
        }
    }
}