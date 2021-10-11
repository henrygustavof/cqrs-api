namespace Project.Application.Devices.Commands.SaveDevice
{
    public class SaveDeviceRequest
    {
        public string SupplyNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
