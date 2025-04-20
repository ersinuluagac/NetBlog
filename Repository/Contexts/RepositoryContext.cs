using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        // Tablolar
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        // DbContextOptions ifadesi olmadan yapılan türetme isteği geçersiz olur ve derlenemez.
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        // Builder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasData(
                new Post() { Id = 1, Title = "HTML", Content = "HTML bir işaretleme dilidir." },
                new Post() { Id = 2, Title = "CSS", Content = "CSS bir işaretleme dilidir ve HTML etiketlerine görsellik eklemek için kullanılır." },
                new Post() { Id = 3, Title = "Javascript", Content = "Javascript bir programlama dilidir. HTML ve CSS ile oluşturulmuş sayfalara etkileşim ve hareket katmak için kullanılır." },
                new Post() { Id = 4, Title = "C#", Content = "C# geniş kapsamlı bir programlama dilidir. İnternet siteleri, Windows uygulamaları veya oyunları yapmak için sıkça kullanılır." }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Software" },
                new Category() { Id = 2, Name = "History" }
            );
        }
    }
}