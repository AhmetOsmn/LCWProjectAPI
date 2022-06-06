using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Persistence.Contexts;
using LCWProjectAPI.Persistence.Repositories;

namespace MiniETicaretAPI.Persistence.Repositories
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(LCWDbContext context) : base(context)
        {
        }
    }
}
