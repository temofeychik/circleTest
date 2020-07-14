using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users;

namespace API.Grpc
{
    public class GrpcClient : IGrpcClient
    {
        private GrpcChannel grpcChannel;
        private User.UserClient _userClient;
        public GrpcClient()
        {
            grpcChannel = GrpcChannel.ForAddress("https://localhost:5001");
            _userClient = new User.UserClient(grpcChannel);
        }

        public UserReply GetUserAsync(int id)
        {
            return _userClient.GetUser(new IdRequest { Id = id });
        }

        public async Task<IEnumerable<UserReply>> GetUsersAsync()
        {
            List<UserReply> userReplies = new List<UserReply>();
            var userResult = _userClient.GetUsers(new Empty());
            try
            {
                await foreach (var user in userResult.ResponseStream.ReadAllAsync())
                {
                    userReplies.Add(user);
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                Console.WriteLine("Stream cancelled.");
            }
            return userReplies;
        }

        public UserReply PostUser(UserRequest user)
        {
            return _userClient.UserPost(user);
        }
    }
}
