using Microsoft.AspNetCore.Identity;

namespace NTierArchitecture.Entities.Models;

public class AppUser : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string LastName { get; set; }
}