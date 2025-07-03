using IotApiDemo1.Domain.Models;
using IotApiDemo1.Domain.Repositories.Interfaces;

public interface IDeviceRepository : IBaseRepository<Device>
{
    Task<List<Device>> GetAllAsync();
    Task<Device?> GetByIdAsync(string id);
    Task<Device> AddAsync(Device device);              
    Task<bool> DeleteAsync(string id);                
    Task UpdateAsync(string id, Device device);        
}
