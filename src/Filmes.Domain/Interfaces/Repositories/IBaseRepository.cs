namespace Filmes.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);

    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}
