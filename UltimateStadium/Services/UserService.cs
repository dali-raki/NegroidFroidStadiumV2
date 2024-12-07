
using UltimateStadium.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp1.Domain;

namespace UltimateStadium.Services
{
    public class UserService : IUserService
    {
        private readonly IUserStorage _userStorage;

       
        public UserService(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public async Task<(UserRole? Role, string Fullname,string password)> AuthenticateUser(string email, string password)
        {
            return await _userStorage.AuthenticateUser(email, password);
        }
        public async Task<bool> CreateAccount(string fullname ,string email, string password, UserRole role)
        {
            return await _userStorage.CreateAccount(fullname,email, password, role);
        }
       
    }
}