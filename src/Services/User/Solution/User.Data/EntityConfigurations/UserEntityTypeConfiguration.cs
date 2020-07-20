using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroserviceDemo.Services.User.Domain.Entities;

namespace MicroserviceDemo.Services.User.Data.EntityConfigurations
{
  public class UserEntityTypeConfiguration : IEntityTypeConfiguration<AppUser>
  {
    public void Configure(EntityTypeBuilder<User.Domain.Entities.AppUser> builder)
    {
      builder.ToTable("User");

      builder.Property(u => u.Id)
        .IsRequired();

      builder.Property(u => u.FirstName)
        .IsRequired(true)
        .HasMaxLength(50);

      builder.Property(u => u.LastName)
        .IsRequired(true)
        .HasMaxLength(50);

      builder.Property(u => u.IsActive)
        .IsRequired(true)
        .HasDefaultValue(true);

    }
  }
}