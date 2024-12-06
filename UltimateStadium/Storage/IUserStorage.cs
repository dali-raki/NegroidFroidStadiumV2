using BlazorApp1.Domain;

namespace UltimateStadium.Storage
{
    public interface IUserStorage
    {
        Task<UserRole?> AuthenticateUser(string email, string password);
        Task<bool> CreateAccount(string email, string password, UserRole role);
    }
}