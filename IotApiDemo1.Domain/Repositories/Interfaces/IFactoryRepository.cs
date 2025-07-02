using IotApiDemo1.Domain.Models;

namespace IotApiDemo1.Domain.Repositories.Interfaces
{
    public interface IFactoryRepository
    {
        Task<List<Factory>> GetAllAsync();
        Task<Factory?> GetByIdAsync(string id);
        Task AddAsync(Factory factory);
        Task UpdateAsync(string id, Factory factory);
        Task DeleteAsync(string id);
    }
}
