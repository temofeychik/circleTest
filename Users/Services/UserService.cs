using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repository;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Users
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(ILogger<UserService> logger,
                            IUserRepository userRepository,
                            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<UserReply> UserPost(UserRequest request, ServerCallContext context)
        {
            try
            {
                var user = _mapper.Map<Domain.User>(request);
                var userResult = await _userRepository.PostAsync(user);
                return _mapper.Map<UserReply>(userResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public override async Task<UserReply> GetUser(IdRequest request, ServerCallContext context)
        {
            try
            {
                var result = await _userRepository.GetAsync(request.Id);
                return _mapper.Map<UserReply>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public override async Task GetUsers(Empty request, IServerStreamWriter<UserReply> responseStream, ServerCallContext context)
        {
            var usersResult = await _userRepository.QueryAsync();
            var users = _mapper.Map<IEnumerable<UserReply>>(usersResult);

            foreach(var user in users)
            {
                await responseStream.WriteAsync(user);
            }
        }
    }
}
