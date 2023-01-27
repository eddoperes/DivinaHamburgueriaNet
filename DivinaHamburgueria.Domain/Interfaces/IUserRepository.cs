using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetByNameAsync(string? name);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);

        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);

        Task<User?> ValidateCredentials(string email, string password);
        Task<bool> RevokeToken(string email);
        Task<User?> RefreshUserInfo(User user);
        Task<User> RemoveAsync(User user);

    }
}
