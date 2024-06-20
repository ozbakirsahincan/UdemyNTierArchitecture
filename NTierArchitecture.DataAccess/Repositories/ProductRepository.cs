using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.DataAccess.Repositories;

internal class ProductRepository : Repository<Product> , IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}