using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task Add(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepository.CreateAsync(user);
        }
     
    }
}
