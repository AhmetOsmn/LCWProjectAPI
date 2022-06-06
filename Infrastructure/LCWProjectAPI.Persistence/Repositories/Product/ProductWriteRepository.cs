using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Persistence.Contexts;
using LCWProjectAPI.Persistence.Repositories;

namespace MiniETicaretAPI.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(LCWDbContext context) : base(context)
        {
        }
    }
}
