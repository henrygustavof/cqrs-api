using System;
using System.Threading.Tasks;
using Project.Application.Consumes.Queries.GetConsumes;

namespace Project.Application.Consumes.Validations
{
    public interface IConsumeValidations
    {
        void ValidateConsumesInDistrictsByZoneId(Guid zoneId);
        void ValidateConsumesByUsers(GetConsumesByUsersQuery consumesByUsersQuery);
        Task ValidateConsumesByDeviceAsync(GetConsumesByDeviceQuery consumesByDeviceQuery);
        Task ValidateConsumesByDeviceMonthlyAsync(GetConsumesByDeviceMonthlyQuery consumesByDeviceMonthlyQuery);
    }
}
