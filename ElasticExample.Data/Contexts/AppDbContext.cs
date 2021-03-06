using ElasticExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ElasticExample.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; } = null!;
        public DbSet<ArticleEntity> ArticleEntities { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
