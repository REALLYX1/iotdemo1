using IotApiDemo1.Domain.Data;
using IotApiDemo1.Domain.Models;
using IotApiDemo1.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace IotApiDemo1.Domain.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(IOptions<DatabaseSetting> options)
            : base(options, "Devices")
        {
        }

        public async Task<Device> AddAsync(Device device)
        {
            return await base.AddAsync(device);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await base.DeleteAsync(id);
        }

        public async Task UpdateAsync(string id, Device device)
        {
            await base.UpdateAsync(id, device);
        }

        public async Task<List<Device>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public async Task<Device?> GetByIdAsync(string id)
        {
            return await base.GetByIdAsync(id);
        }
    }
}
