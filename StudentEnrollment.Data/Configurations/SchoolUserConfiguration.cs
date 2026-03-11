using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations;


internal class SchoolUserConfiguration : IEntityTypeConfiguration<SchoolUser>
{
    public void Configure(EntityTypeBuilder<SchoolUser> builder)
    {
        builder.HasData(
      new SchoolUser
      {
          Id = "8f805e2b-a44d-4a1b-b491-0d8f4175e981",
          Email = "schooladmin@localhost.com",
          NormalizedEmail = "SCHOOLADMIN@LOCALHOST.COM",
          NormalizedUserName = "SCHOOLADMIN@LOCALHOST.COM",
          UserName = "SCHOOLADMIN@LOCALHOST.COM",
          FirstName = "School",
          LastName = "Admin",
          PasswordHash = "AQAAAAIAAYagAAAAEOppS140pm1QK0e1a9EaCMy+7mwCa24VwpnZqo/aaemvPQsiCfUW/28UejSaRHE3sg==", // Static hash for P@ssword!
          EmailConfirmed = true,
          SecurityStamp = "18a72843-04ad-498f-aa40-36bb4edf804e",
          ConcurrencyStamp = "d59eaa62-98fa-40d8-8353-c6c3d6c1a86b"
      },
      new SchoolUser
      {
          Id = "264e25b7-6924-4cb4-aa9f-020ad53ef821",
          Email = "schooluser@localhost.com",
          NormalizedEmail = "SCHOOLUSER@LOCALHOST.COM",
          NormalizedUserName = "SCHOOLUSER@LOCALHOST.COM",
          UserName = "SCHOOLUSER@LOCALHOST.COM",
          FirstName = "School",
          LastName = "User",
          PasswordHash = "AQAAAAIAAYagAAAAEBCqeyy/X1ADwTUMyjX1YATArcBE3cviRfZzYtu3Cz4oNzqeTA312ea5qhJtq0rEvg==", // Static hash for P@ssword1
          EmailConfirmed = true,
          SecurityStamp = "9bda1367-8d1d-4509-900b-ecf2b1ff6873",
          ConcurrencyStamp = "68703f9a-efc5-4f2b-aedd-7e498c7a549f"
      });
    }
}
