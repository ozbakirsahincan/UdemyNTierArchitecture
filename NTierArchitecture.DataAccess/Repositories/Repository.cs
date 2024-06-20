using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.DataAccess.Repositories;

//Verilen işleri Databaseye yönlendirecek.
internal class Repository<T> : IRepository<T> where T : class
{

    //Databaseye bağlantı servisinin örneğini alıyoruz
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        // Databaseye gönderilecek işler için new'leme yapmak yerine 
        // servisin örneğini alarak kullanıyoruz ve her seferinden new'leme işini IoC containere devrederek
        // hem işten hem performanstan kazanıyoruz
        
        // IoC containere devretmek bizi ayrı ayrı entitylerin içerisine DbSet yazma zorunluluğundan kurtarıyor
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Remove(T entity)
    {
        _context.Update(entity);
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(expression).FirstOrDefaultAsync(cancellationToken);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsQueryable();
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().AsNoTracking().Where(expression).AsQueryable();
    }
}