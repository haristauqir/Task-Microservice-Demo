using MicroserviceDemo.Services.User.Data.EntityConfigurations;
using MicroserviceDemo.Services.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace User.Data.Database
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        } 

         public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityTypeConfiguration());
            builder.Seed();
        } 
    }
}