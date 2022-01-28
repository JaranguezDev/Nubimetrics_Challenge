using System;

namespace Nubimetrics_Challenge.Services.User.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
