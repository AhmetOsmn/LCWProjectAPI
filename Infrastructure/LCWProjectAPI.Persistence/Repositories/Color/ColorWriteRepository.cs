using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Persistence.Contexts;
using LCWProjectAPI.Persistence.Repositories;

namespace MiniETicaretAPI.Persistence.Repositories
{
    public class ColorWriteRepository : WriteRepository<Color>, IColorWriteRepository
    {
        public ColorWriteRepository(LCWDbContext context) : base(context)
        {
        }
    }
}
