using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Domain.Entity;

namespace Project.Domain.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllByFilterParamsAsync(string docNumber = "");
        Task<Domain.Entity.User> GetByUserNameAsync(string userName);
    }
}
