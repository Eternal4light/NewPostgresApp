using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewPostgresApp
{
    public class ApplicationContext : DbContext
    {
       /* static ApplicationContext()
        {
           Database.SetInitializer<ApplicationContext>(new BlogInitializer());
        }
        */
        public DbSet<Writers> Writers { get; set; }
        public DbSet<Posts> Posts { get; set; }

        public ApplicationContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb5;Username=postgres;Password=postgres");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Writers>().HasData(new List<Writers>()
            {
              new Writers() { ID = Guid.Parse("15a96f15-5ebb-4764-8213-11dce2002ef5"), Name = "Adam" },
                new Writers() { Name = "Bob", ID = Guid.Parse("630e64fc-2334-468b-af6d-d08d753af05e") },
                new Writers() { Name = "Charlie", ID = Guid.Parse("25e5551c-529b-4d81-9ded-fbda38a1f039") }
            });

            modelBuilder.Entity<Posts>().HasData(new List<Posts>()
            {
                new Posts() { Name = "First post", Content = "111", WriterId =Guid.Parse("15a96f15-5ebb-4764-8213-11dce2002ef5"), ID = Guid.NewGuid() },
                new Posts() { Name = "Second post", Content = "222", WriterId = Guid.Parse("15a96f15-5ebb-4764-8213-11dce2002ef5"), ID = Guid.NewGuid() },
                new Posts() { Name = "Third post", Content = "333", WriterId = Guid.Parse("15a96f15-5ebb-4764-8213-11dce2002ef5"), ID = Guid.NewGuid() },
                new Posts() { Name = "Fourth post", Content = "444", WriterId = Guid.Parse("630e64fc-2334-468b-af6d-d08d753af05e"), ID = Guid.NewGuid() },
                new Posts() { Name = "Fifth post", Content = "555", WriterId = Guid.Parse("630e64fc-2334-468b-af6d-d08d753af05e"), ID = Guid.NewGuid() },
                new Posts() { Name = "Sixth post", Content = "6*6", WriterId = Guid.Parse("630e64fc-2334-468b-af6d-d08d753af05e"), ID = Guid.NewGuid() },
                new Posts() { Name = "Seventh post", Content = "777", WriterId = Guid.Parse("25e5551c-529b-4d81-9ded-fbda38a1f039"), ID = Guid.NewGuid() },
                new Posts() { Name = "Eighth post", Content = "888", WriterId = Guid.Parse("25e5551c-529b-4d81-9ded-fbda38a1f039"), ID = Guid.NewGuid() },
                new Posts() { Name = "Ninth post", Content = "999", WriterId = Guid.Parse("25e5551c-529b-4d81-9ded-fbda38a1f039"), ID = Guid.NewGuid() },
            });
        }
    }
}
