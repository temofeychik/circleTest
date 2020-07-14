using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public partial class UserRepository : IUserRepository
    {
        public List<User> users;
        public UserRepository()
        {
            var Ids = 0;
            users = new Faker<User>()
                      .RuleFor(p => p.Id, f => Ids++)
                      .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                      .RuleFor(p => p.LastName, f => f.Person.LastName)
                      .RuleFor(p => p.City, f => f.Address.City())
                      .RuleFor(p => p.DateOfBith, f => f.Date.Soon().ToString())
                      .Generate(10);
        }
    }
}
