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
    }
}
