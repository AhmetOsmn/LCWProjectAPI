using LCWProjectAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace LCWProjectAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
