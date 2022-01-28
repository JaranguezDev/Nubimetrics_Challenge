using Microsoft.AspNetCore.Mvc;
using Nubimetrics_Challenge.Services.User.Dtos;
using Nubimetrics_Challenge.Services.User.Interfaces;
using Nubimetrics_Challenge.WebApi.Infraestructure;

namespace Nubimetrics_Challenge.WebApi.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UserController : CrudControllerBase<UserDto, IUserService>
    {
        public UserController(IUserService userService)
            : base(userService) { }
    }
}
