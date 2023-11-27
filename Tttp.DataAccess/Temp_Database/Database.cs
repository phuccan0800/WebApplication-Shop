using Microsoft.EntityFrameworkCore;
using WebApplicationTEST.Models;

namespace WebApplicationTEST.DataAccess.Temp_Database
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) 
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id= 1, Name="Anime", DisplayOrder=1 },
                new CategoryModel { Id = 2, Name="Hentai", DisplayOrder=2 },
                new CategoryModel { Id = 3, Name="Sex", DisplayOrder=3}
                );
            modelBuilder.Entity<ProductModel>();
        }


    }
}
