using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public partial class UserRepository
    {
        public async Task<IEnumerable<User>> QueryAsync()
        {
            //fake async
            await Task.Delay(1);
            return users;
        }
    }
}
