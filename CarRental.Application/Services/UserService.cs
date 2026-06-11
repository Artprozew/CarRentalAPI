using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Pagination;
using System.Security.Cryptography;
using System.Text;

namespace CarRental.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserLoginDTO> CreateAsync(UserLoginDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);

            if (userDTO.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                byte[] passwordSalt = hmac.Key;

                user.ChangePassword(passwordHash, passwordSalt);
            }

            User alteredUser = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserLoginDTO>(alteredUser);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            User alteredUser = await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(alteredUser);
        }

        public async Task<UserDTO?> DeleteAsync(uint id)
        {
            User? user = await _userRepository.DeleteAsync(id);
            return _mapper.Map<UserDTO?>(user);
        }

        public async Task<PagedList<UserDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            PagedList<User> users = await _userRepository.GetAllAsync(pageNumber, pageSize);
            IEnumerable<UserDTO> userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);

            return new PagedList<UserDTO>(userDTOs, pageNumber, pageSize, users.TotalCount);
        }

        public async Task<UserDTO?> GetAsync(int id)
        {
            User? user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> RegisteredUserExistsAsync()
        {
            return await _userRepository.RegisteredUserExistsAsync();
        }
    }
}
