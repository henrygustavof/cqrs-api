using System.Threading;
using System.Threading.Tasks;
using Project.Application.Configuration.Queries;
using Project.Application.Users.Dto;
using Project.Application.Users.Services;
using Project.Application.Users.Validations;

namespace Project.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly IUserValidations _userValidations;
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserValidations userValidations,
            IUserService userService)
        {
            _userValidations = userValidations;
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            _userValidations.ValidateConsumesByUserName(request);
            return await _userService.GetByUserNameAsync(request);
        }
    }
}
