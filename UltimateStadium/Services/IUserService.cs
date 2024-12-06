using BlazorApp1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UltimateStadium.Services
{
    public interface IUserService
    {
        Task<UserRole?> AuthenticateUser(string email, string password);  
        Task<bool> CreateAccount(string email, string password, UserRole role);
    }
}