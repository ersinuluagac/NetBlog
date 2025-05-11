using System.Reflection;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Config;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        // Tablolar
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        // DbContextOptions ifadesi olmadan yapılan türetme isteği geçersiz olur ve derlenemez.
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        // Builder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()) // Assembly'deki EntityType'lar taranır.
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType)) // BaseEntity'den türeyenleri bulur.
                {
                    modelBuilder.Entity(entityType.ClrType) // CreatedAt
                        .Property(nameof(BaseEntity.CreatedAt))
                        .HasDefaultValueSql("GETDATE()");

                    
                }
            }

            // Tek tek verilebilir
            /*
                modelBuilder.ApplyConfiguration(new PostConfig());
                modelBuilder.ApplyConfiguration(new CategoryConfig());
            */
            // Assembly'den alınabilir.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Çalışan Assembly'den getir (Assembly: dll, exe).
        }
    }
}