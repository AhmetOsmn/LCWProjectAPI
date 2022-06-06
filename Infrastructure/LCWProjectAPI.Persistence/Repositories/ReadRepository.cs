using EntityLayer.Concrete.Utilities;
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

        public IDataResult<IQueryable<T>> GetAll()
        {
            var query = Table.AsQueryable();
            if (query.Any())
            {
                return new SuccessDataResult<IQueryable<T>>(query, "Listeleme İşlemi Başarılı");
            }
            return new ErrorDataResult<IQueryable<T>>("Listelenecek Bir Şey Bulunamadı");
        }

        public IDataResult<IQueryable<T>> GetWhere(Expression<Func<T, bool>> method)
        {
            var query = Table.Where(method);
            if (query.Any())
            {
                return new SuccessDataResult<IQueryable<T>>(query, "Listeleme İşlemi Başarılı"); ;
            }
            return new ErrorDataResult<IQueryable<T>>("Listelenecek Bir Şey Bulunamadı");
        }

        public async Task<IDataResult<T>> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
            var result = await query.FirstOrDefaultAsync(method);

            if (result != null)
            {
                return new SuccessDataResult<T>(result, "Getirme İşlemi Başarılı");
            }

            return new ErrorDataResult<T>("Getirecek Bir Şey Bulunamadı");
        }

        public async Task<IDataResult<T>> GetByIdAsync(string id)
        {
            var query = Table.AsQueryable();
            var result = await query.FirstOrDefaultAsync(data => data.Id == int.Parse(id));

            if (result != null)
            {
                return new SuccessDataResult<T>(result, "Getirme İşlemi Başarılı");
            }

            return new ErrorDataResult<T>("Getirecek Bir Şey Bulunamadı");
        }
    }
}
