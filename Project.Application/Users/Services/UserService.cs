using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Application.Configuration.Constants;
using Project.Application.Devices.Dto;
using Project.Application.Users.Dto;
using Project.Application.Users.Queries.GetUsers;
using Project.Domain.Filters;
using Project.Domain.Repository;

namespace Project.Application.Users.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<UserDto> GetByUserNameAsync(GetUserQuery userQuery)
        {
            var user = await _userRepository.GetByUserNameAsync(userQuery.UserName);

            var devices = await _unitOfWork.Devices.GetAllByUserNameAsync(userQuery.UserName);

            var mappedDevices = _mapper.Map<List<DeviceDto>>(devices);

            var consumes = await _unitOfWork.Consumes.GetAllByFilterParametersAsync(new ConsumeFilterParameters
            {
                UserName = userQuery.UserName
            });

            var totalConsume = Math.Round(consumes.Sum(p => p.Value), Number.RoundNumberDecimal);

            return new UserDto
            {
                UserName = user.UserName,
                FullName = user.FullName,
                DocNumber = user.DocNumber,
                Consume = totalConsume,
                Address = user.Address,
                Devices = mappedDevices
            };
        }
    }
}
