using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace IotApiDemo1.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(string id);
        Task<TEntity> UpdateAsync(string id, TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        IMongoCollection<TEntity> GetCollection();
    }
}
