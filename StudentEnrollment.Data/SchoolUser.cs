
using Microsoft.AspNetCore.Identity;

namespace StudentEnrollment.Data;

public class SchoolUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }


}
