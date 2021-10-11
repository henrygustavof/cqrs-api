using System.Threading.Tasks;
using Project.Application.Users.Dto;
using Project.Application.Users.Queries.GetUsers;

namespace Project.Application.Users.Services
{
    public interface IUserService
    {
        Task<UserDto> GetByUserNameAsync(GetUserQuery userQuery);
    }
}
