using Project.Application.Configuration.Commands;
using Project.Application.Devices.Dto;

namespace Project.Application.Devices.Commands.SaveDevice
{
    public class SaveDeviceCommand : CommandBase<DeviceDto>
    {
        public string SupplyNumber { get; }
        public double Latitude { get; }
        public double Longitude { get; }

        public SaveDeviceCommand(string supplyNumber, double latitude, double longitude)
        {
            SupplyNumber = supplyNumber;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
