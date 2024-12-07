using BlazorApp1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UltimateStadium.Services
{
    public interface IUserService
    {
        Task<(UserRole? Role, string Fullname, string password)> AuthenticateUser(string email, string password);  
        Task<bool> CreateAccount(string fullname,string email, string password, UserRole role);
    }
}