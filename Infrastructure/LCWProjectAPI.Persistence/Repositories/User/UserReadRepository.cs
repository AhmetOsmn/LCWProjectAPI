using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Persistence.Contexts;

namespace LCWProjectAPI.Persistence.Repositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(LCWDbContext context) : base(context)
        {

        }
    }
}
