using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class UserConfig : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(u => u.Id);

      builder.Property(u => u.UserName).HasColumnType("nvarchar(50)").IsRequired();

      builder.HasData(
        new User() {Id = 1, UserName = "Arbores"},
        new User() {Id = 2, UserName = "Surgens"}
      );
    }
  }
}