using AutoMapper;
using Nubimetrics_Challenge.EntityFrameworkCore.Repositories.User;
using Nubimetrics_Challenge.Services.BaseService.Services;
using Nubimetrics_Challenge.Services.User.Dtos;
using Nubimetrics_Challenge.Services.User.Interfaces;

namespace Nubimetrics_Challenge.Services.User.Services
{
    public class UserService : CrudBaseService<Core.Entities.User, UserDto>, IUserService
    {
        public UserService(
            IUserRepository userRepository,
            IMapper mapper
            ) : base(userRepository, mapper)
        {
        }
    }
}
