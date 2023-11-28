using Microsoft.EntityFrameworkCore;
using WebApplicationTEST.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationTEST.DataAccess.Temp_Database
{
    public class Database : IdentityDbContext<IdentityUser>
    {
        public Database(DbContextOptions<Database> options) : base(options) 
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Users> Users {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryModel>();
            modelBuilder.Entity<ProductModel>();
            modelBuilder.Entity<Users>();
        }


    }
}
