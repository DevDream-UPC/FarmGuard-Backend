using FarmGuard_Backend.Shared.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;

public abstract class BaseRepository<T>: IBaseRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected BaseRepository(AppDbContext context) => Context = context;
    
    public async Task AddAsync(T entity) => await Context.Set<T>().AddAsync(entity);


    public async Task<T?> FindByIdAsync(int id) => await Context.Set<T>().FindAsync(id);

    public void Update(T entity) => Context.Set<T>().Update(entity);
    

    public void Remove(T entity) => Context.Set<T>().Remove(entity);

    public async Task<IEnumerable<T>> ListAsync() => await Context.Set<T>().ToListAsync();

}