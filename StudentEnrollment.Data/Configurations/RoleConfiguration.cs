using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
      new IdentityRole
      {
          Id = "264e25b7-6924-4cb4-aa9f-020ad53ef821",
          Name = "Administrator",
          NormalizedName = "ADMINISTRATOR",
          ConcurrencyStamp = "5322123f-bb76-44e0-9472-4e3ca81918aa"
      },
      new IdentityRole
      {
          Id = "8f805e2b-a44d-4a1b-b491-0d8f4175e981",
          Name = "User",
          NormalizedName = "USER",
          ConcurrencyStamp = "51a1ec45-daf9-4621-8585-fb371dea6887"
      }
  );
    }
}
