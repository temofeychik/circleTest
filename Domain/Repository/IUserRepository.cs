using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> QueryAsync();
        Task<User> GetAsync(int id);
        Task<User> PostAsync(User user);
    }
}
