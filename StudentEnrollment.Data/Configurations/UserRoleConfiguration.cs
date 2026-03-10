using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations;

internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
      new IdentityUserRole<string>
      {
          RoleId = "264e25b7-6924-4cb4-aa9f-020ad53ef821",
          UserId = "8f805e2b-a44d-4a1b-b491-0d8f4175e981"
      },
      new IdentityUserRole<string>
      {
          RoleId = "8f805e2b-a44d-4a1b-b491-0d8f4175e981",
          UserId = "264e25b7-6924-4cb4-aa9f-020ad53ef821"
      }
  );
    }
}