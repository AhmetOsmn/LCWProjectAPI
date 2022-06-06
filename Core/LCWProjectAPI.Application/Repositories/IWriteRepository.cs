using EntityLayer.Concrete.Utilities;
using LCWProjectAPI.Domain.Entities.Common;

namespace LCWProjectAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<IResult> AddAsync(T model);
        Task<IResult> AddRangeAsync(List<T> datas);
        IResult Remove(T model);
        IResult RemoveRange(List<T> datas);
        Task<IResult> RemoveAsync(string id);
        IResult Update(T model);

        Task<int> SaveAsync();
    }
}
