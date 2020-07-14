using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users;

namespace API.Grpc
{
    public interface IGrpcClient
    {
        Task<IEnumerable<UserReply>> GetUsersAsync();
        UserReply GetUserAsync(int id);
        UserReply PostUser(UserRequest user);
    }
}
