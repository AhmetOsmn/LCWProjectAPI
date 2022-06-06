using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Domain.Entities.Common;
using LCWProjectAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LCWProjectAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly LCWDbContext _context;

        public ReadRepository(LCWDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            var query = Table.Where(method);
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
         
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var query = Table.AsQueryable();
   
            return await query.FirstOrDefaultAsync(data => data.Id == int.Parse(id));
        }
    }
}
