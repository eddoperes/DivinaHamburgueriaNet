using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(IUserRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserNoSecretDTO>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserNoSecretDTO>>(users);
        }

        public async Task<IEnumerable<UserNoSecretDTO>> GetByName(string? name)
        {
            var users = await _userRepository.GetByNameAsync(name);
            return _mapper.Map<IEnumerable<UserNoSecretDTO>>(users);
        }

        public async Task<UserNoSecretDTO?> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserNoSecretDTO>(user);
        }

        public async Task Add(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user = await _userRepository.CreateAsync(user);
            userDTO.Id = user.Id;
        }

        public async Task<UserNoSecretDTO?> Patch(UserNoSecretDTO userNoSecretDTO)
        {
            var previousUser = await _userRepository.GetByIdAsync(userNoSecretDTO.Id);
            if (previousUser != null)
            {
                previousUser.Update(userNoSecretDTO.Name,
                                    (User.UserType) userNoSecretDTO.Type,
                                    (User.UserState) userNoSecretDTO.State,
                                    userNoSecretDTO.Email);
                var user = await _userRepository.UpdateAsync(previousUser);
                return _mapper.Map<UserNoSecretDTO>(user);
            }
            return null;
        }

        public async Task Remove(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
                await _userRepository.RemoveAsync(user);
        }

    }
}
