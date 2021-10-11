using System;
using Project.Application.Configuration.Constants;
using Project.Application.Configuration.Models;
using Project.Application.Users.Queries.GetUsers;

namespace Project.Application.Users.Validations
{
    public class UserValidations: IUserValidations
    {
        public void ValidateConsumesByUserName(GetUserQuery userQuery)
        {
            ErrorNotification notification = new ErrorNotification();

            if (!userQuery.IsAdmin && userQuery.LoggedUserName != userQuery.UserName)
            {
                notification.AddError(ValidationErrorMessage.NoTMatchUserNameWithLoggedUserName);

            }
            if (string.IsNullOrEmpty(userQuery.UserName))
            {
                notification.AddError(ValidationErrorMessage.MandatoryUserName);

            }

            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }
        }
    }
}
