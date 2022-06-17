using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LCWProjectAPI.Persistence.Contexts
{
    public class LCWDbContext : IdentityDbContext<User>
    {
        public LCWDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<User> Users   { get; set; }

    }
}
