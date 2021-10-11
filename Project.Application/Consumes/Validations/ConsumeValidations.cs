using System;
using System.Linq;
using System.Threading.Tasks;
using Project.Application.Configuration.Constants;
using Project.Application.Configuration.Models;
using Project.Application.Consumes.Queries.GetConsumes;
using Project.Domain.Repository;

namespace Project.Application.Consumes.Validations
{
    public class ConsumeValidations: IConsumeValidations
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsumeValidations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void ValidateConsumesInDistrictsByZoneId(Guid zoneId)
        {
            ErrorNotification notification = new ErrorNotification();

            if (zoneId == Guid.Empty)
            {
                notification.AddError(ValidationErrorMessage.MandatoryZoneId);
            }
         
            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }
        }

        public void ValidateConsumesByUsers(GetConsumesByUsersQuery consumesByUsersQuery)
        {
            ErrorNotification notification = new ErrorNotification();

            if (string.IsNullOrEmpty(consumesByUsersQuery.StartDate) ||
                string.IsNullOrEmpty(consumesByUsersQuery.EndDate))
            {
                notification.AddError(ValidationErrorMessage.MandatoryStartEndDate);
                
            }

            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }
        }

        public async Task ValidateConsumesByDeviceAsync(GetConsumesByDeviceQuery consumesByDeviceQuery)
        {
            ErrorNotification notification = new ErrorNotification();

            if (consumesByDeviceQuery.DeviceId == Guid.Empty)
            {
                notification.AddError(ValidationErrorMessage.MandatoryDeviceId);
            }

            if (string.IsNullOrEmpty(consumesByDeviceQuery.StartDate) ||
                string.IsNullOrEmpty(consumesByDeviceQuery.EndDate))
            {
                notification.AddError(ValidationErrorMessage.MandatoryStartEndDate);

            }

            if (!consumesByDeviceQuery.IsAdmin)
            {
                var devices = await _unitOfWork.Devices.GetAllByUserNameAsync(consumesByDeviceQuery.LoggedUserName);

                if (!devices.Select(device => device.Id).Contains(consumesByDeviceQuery.DeviceId))
                {
                    notification.AddError(ValidationErrorMessage.DeviceNotBelongsLoggedUser);
                }
            }

            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }
        }

        public async Task ValidateConsumesByDeviceMonthlyAsync(GetConsumesByDeviceMonthlyQuery consumesByDeviceMonthlyQuery)
        {
            ErrorNotification notification = new ErrorNotification();

            if (consumesByDeviceMonthlyQuery.DeviceId == Guid.Empty)
            {
                notification.AddError(ValidationErrorMessage.MandatoryDeviceId);
            }

            if (!consumesByDeviceMonthlyQuery.IsAdmin)
            {
                var devices = await _unitOfWork.Devices.GetAllByUserNameAsync(consumesByDeviceMonthlyQuery.LoggedUserName);

                if (!devices.Select(device => device.Id).Contains(consumesByDeviceMonthlyQuery.DeviceId))
                {
                    notification.AddError(ValidationErrorMessage.DeviceNotBelongsLoggedUser);
                }
            }

            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }
        }
    }
}
