using System.Linq.Expressions;
using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public abstract class RepositoryBase<T>(RepositoryContext repositoryContext) : IRepositoryBase<T> where T : class
{
    public IQueryable<T> FindAll(bool trackChanges) =>
        trackChanges ?
            repositoryContext.Set<T>() :
            repositoryContext.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => 
        trackChanges ? 
            repositoryContext.Set<T>().Where(expression) :
            repositoryContext.Set<T>().Where(expression).AsNoTracking();
        
    public void Create(T entity) => repositoryContext.Set<T>().Add(entity);
    public void Update(T entity) => repositoryContext.Set<T>().Update(entity);
    public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);
}