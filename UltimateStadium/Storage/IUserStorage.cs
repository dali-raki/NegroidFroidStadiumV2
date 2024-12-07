using BlazorApp1.Domain;

namespace UltimateStadium.Storage
{
    public interface IUserStorage
    {
        Task<(UserRole Role, string Fullname, string password1)> AuthenticateUser(string email, string password);
        Task<bool> CreateAccount( string fullname ,string email, string password, UserRole role);
    }
}