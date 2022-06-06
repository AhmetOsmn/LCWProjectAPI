using EntityLayer.Concrete.Utilities;
using LCWProjectAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace LCWProjectAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IDataResult<IQueryable<T>> GetAll();
        IDataResult<IQueryable<T>> GetWhere(Expression<Func<T, bool>> method);
        Task<IDataResult<T>> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<IDataResult<T>> GetByIdAsync(string id);
    }
}
