namespace Project.Application.Configuration.Constants
{
    public static class ValidationErrorMessage
    {
        public const string InvalidJson = "Invalid JSON data in request body";
        public const string InvalidCredential = "Invalid credentials.Please try again.";

        public const string AccountDisabled = "Your account is disabled, please contact with the web master";
        public const string ConfirmEmail = "Please confirm your email or contact with the web master";
        public const string AccountLockedOut = "Your account has been locked out for";
        public const string AccountLockedOutAttempts = "minutes due to multiple failed login attempts.";
        public const string InvalidCredentials = "Invalid credentials. You have";
        public const string InvalidCredentialsAttempts = " more attempt(s) before your account gets locked out..";

        public const string MandatoryConsumeId = "ConsumeId is mandatory";
        public const string MandatoryZoneId = "ZoneId is mandatory";
        public const string MandatoryStartEndDate = "StartDate,endDate are mandatory";
        public const string MandatoryUserId = "UserId is mandatory";
        public const string MandatoryZoneIdAndDistrictId = "ZoneId and DistrictId are mandatory";
        public const string MandatoryDeviceIdAndStartDateAndEndDate = "DeviceId, startDate and endDate are mandatory";
        public const string MandatoryDeviceId = "DeviceId is mandatory";
        public const string MandatoryUserName = "UserName is mandatory";
        public const string NoTMatchUserNameWithLoggedUserName = "Not match userName with logged userName";
        public const string DeviceNotBelongsLoggedUser = "Device doesnt belong to the loggedUser";
    }
}
