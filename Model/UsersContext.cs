using Microsoft.EntityFrameworkCore;


namespace TestAPI.Models
{
    public class UsersContext : DbContext
    {
        
        public UsersContext(DbContextOptions<UsersContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Users>().HasKey(x => new{x.UserId});

        }

        public DbSet<Users> Users { get; set; } = null;
        
    }
}