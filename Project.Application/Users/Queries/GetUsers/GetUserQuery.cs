using Project.Application.Configuration.Queries;
using Project.Application.Users.Dto;

namespace Project.Application.Users.Queries.GetUsers
{
    public class GetUserQuery : IQuery<UserDto>
    {
        public bool IsAdmin { get; set; }
        public string LoggedUserName { get; set; }
        public string UserName { get; set; }
    }
}
