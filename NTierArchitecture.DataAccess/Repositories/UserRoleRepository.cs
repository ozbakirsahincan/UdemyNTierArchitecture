using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.DataAccess.Repositories;

internal class UserRoleRepository : Repository<UserRole> , IUserRoleRepository
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}