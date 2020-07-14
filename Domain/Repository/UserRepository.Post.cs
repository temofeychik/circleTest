using System.Threading.Tasks;

namespace Domain.Repository
{
    public partial class UserRepository
    {
        public async Task<User> PostAsync(User user)
        {
            //fake async
            await Task.Delay(1);
            users.Add(user);
            return user;
        }
    }
}
