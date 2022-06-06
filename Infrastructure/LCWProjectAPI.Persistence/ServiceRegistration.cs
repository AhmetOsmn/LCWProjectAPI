using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Persistence.Contexts;
using LCWProjectAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniETicaretAPI.Persistence.Repositories;

namespace LCWProjectAPI.Persistence
{
    public static class ServisRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<LCWDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IColorReadRepository, ColorReadRepository>();
            services.AddScoped<IColorWriteRepository, ColorWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        }
    }
}
