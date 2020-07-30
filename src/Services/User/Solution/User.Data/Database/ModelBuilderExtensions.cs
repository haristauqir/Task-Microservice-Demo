using MicroserviceDemo.Services.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace User.Data.Database
{
  public static class ModelBuilderExtensions
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AppUser>().HasData(
          new List<AppUser>()
            {
                new AppUser() { Id = 3, FirstName = "Y", LastName = "Zhou"},
                new AppUser() { Id = 4, FirstName = "Shawn", LastName = "M"},
                new AppUser() { Id = 5, FirstName = "Jackie", LastName = "Yan"}
            }
      );
    }
  }
}