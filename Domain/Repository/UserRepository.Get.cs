using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public partial class UserRepository
    {
        public async Task<User> GetAsync(int id)
        {
            return (await QueryAsync()).FirstOrDefault(x => x.Id == id);
        }
    }
}
