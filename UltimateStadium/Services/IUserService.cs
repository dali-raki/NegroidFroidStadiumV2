using BlazorApp1.Domain;

namespace UltimateStadium.Services.UserServie;

public interface IUserService
{
    public Task<bool> createNewUser(string email, string password);
    public Task<User> login(string email,string password);
}