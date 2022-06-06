using EntityLayer.Concrete.Utilities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Domain.Entities.Common;
using LCWProjectAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LCWProjectAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly LCWDbContext _context;

        public WriteRepository(LCWDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<IResult> AddAsync(T model)
        {
            if(model != null)
            {
                EntityEntry<T> entityEntry = await Table.AddAsync(model);
                if (entityEntry.State == EntityState.Added)
                {
                    return new SuccessResult("Ekleme İşlemi Başarılı");
                }
            }
            return new ErrorResult("Geçersiz Veri Girişi");
        }

        public async Task<IResult> AddRangeAsync(List<T> datas)
        {
            if(datas != null)
            {
                await Table.AddRangeAsync(datas);
                return new SuccessResult("Ekleme İşlemi Başarılı");
            }
            return new ErrorResult("Geçeriz Veri Girişi");
        }

        public IResult Remove(T model)
        {
            if(model != null)
            {
                EntityEntry<T> entityEntriy = Table.Remove(model);
                if (entityEntriy.State == EntityState.Deleted)
                {
                    return new SuccessResult("Silme İşlemi Başarılı");
                }
            }
            return new ErrorResult("Geçeriz Veri Girişi");
        }

        public IResult RemoveRange(List<T> datas)
        {
            if(datas != null)
            {
                Table.RemoveRange(datas);
                return new SuccessResult("Silme İşlemi Başarılı");
            }
            return new ErrorResult("Geçersiz Veri Girişi");
        }

        public async Task<IResult> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == int.Parse(id));
            if(model != null)
            {
                Remove(model);
                return new SuccessResult("Silme İşlemi Başarılı");
            }
            return new ErrorResult("Geçersiz ID");
        }

        public IResult Update(T model)
        {
            if(model != null)
            {
                EntityEntry entityEntry = Table.Update(model);
                if (entityEntry.State == EntityState.Modified)
                {
                    return new SuccessResult("Güncelleme İşlemi Başarılı");
                }
            }
            return new ErrorResult("Güncelleme Başarısız");
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
