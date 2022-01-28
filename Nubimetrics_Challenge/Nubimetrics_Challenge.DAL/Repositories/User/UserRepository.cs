using Nubimetrics_Challenge.EntityFrameworkCore.Infraestructure.BaseRepository;

namespace Nubimetrics_Challenge.EntityFrameworkCore.Repositories.User
{
    public class UserRepository : BaseRepository<Core.Entities.User>, IUserRepository
    {
        public UserRepository(NubimetricsContext context) : base(context) { }
    }
}
