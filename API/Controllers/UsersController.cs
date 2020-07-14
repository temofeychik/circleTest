using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Grpc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Users;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IGrpcClient _grpcClient;

        public UsersController(ILogger<UsersController> logger,
                                IGrpcClient grpcClient)
        {
            _logger = logger;
            _grpcClient = grpcClient;
        }

        [HttpGet]
        public async Task<IEnumerable<UserReply>> Get()
        {
            return await _grpcClient.GetUsersAsync();
        }

        [HttpGet("{id}")]
        public UserReply Get(int id)
        {
            return _grpcClient.GetUserAsync(id);
        }

        [HttpPost("{user}")]
        public UserReply Get(UserRequest user)
        {
            return _grpcClient.PostUser(user);
        }
    }
}
