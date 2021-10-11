using Project.Application.Users.Queries.GetUsers;

namespace Project.Application.Users.Validations
{
    public interface IUserValidations
    {
        void ValidateConsumesByUserName(GetUserQuery userQuery);
    }
}
