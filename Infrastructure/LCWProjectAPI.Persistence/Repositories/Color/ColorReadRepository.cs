using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Persistence.Contexts;

namespace LCWProjectAPI.Persistence.Repositories
{
    public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
    {
        public ColorReadRepository(LCWDbContext context) : base(context)
        {

        }
    }
}
