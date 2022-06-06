using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Persistence.Contexts;
using LCWProjectAPI.Persistence.Repositories;

namespace MiniETicaretAPI.Persistence.Repositories
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(LCWDbContext context) : base(context)
        {
        }
    }
}
