using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByEmailAsync(string email);

        Task<User> CreateAsync(User user);

        Task<User?> ValidateCredentials(string email, string password);
        Task<bool> RevokeToken(string email);
        Task<User?> RefreshUserInfo(User user);

    }
}
