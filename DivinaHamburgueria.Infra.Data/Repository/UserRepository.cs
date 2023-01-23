using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _applicationDbContext.CustomUsers!.ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _applicationDbContext.CustomUsers!
                                              .Where(m => m.Email == email)
                                              .FirstOrDefaultAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            var pass = ComputHash(user.Password, new SHA256CryptoServiceProvider());
            user.NotifyEncryptedPassword(pass);

            _applicationDbContext.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> ValidateCredentials(string email, string password)
        {
            var pass = ComputHash(password, new SHA256CryptoServiceProvider());
            return await _applicationDbContext.CustomUsers!.FirstOrDefaultAsync(u => u.Email == email && u.Password == pass);
        }


        public async Task<bool> RevokeToken(string email)
        {
            var user = _applicationDbContext.CustomUsers!.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return false;
            user.NotifyRefreshToken("");
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User?> RefreshUserInfo(User user)
        {

            //if (_applicationDbContext.CustomUsers!.Any(u => u.Id.Equals(user.Id)))
            //    return null;

            var user_previous = await _applicationDbContext.CustomUsers!.SingleOrDefaultAsync(i => i.Id.Equals(user.Id));

            if (user_previous != null)
            {
                try
                {
                    _applicationDbContext.Entry(user_previous).CurrentValues.SetValues(user);
                    await _applicationDbContext.SaveChangesAsync();
                    return user_previous;
                }
                catch (Exception ex)
                {
                    throw new Exception("Update Error", ex);
                }
            }
            else
            {
                return user_previous;
            }

        }

        private string ComputHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inpuBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inpuBytes);
            return BitConverter.ToString(hashedBytes);
        }




    }
}
