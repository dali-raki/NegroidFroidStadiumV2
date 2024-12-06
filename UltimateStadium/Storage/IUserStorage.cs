using BlazorApp1.Domain;

namespace UltimateStadium.Storage.UserStorage;

public interface IUserStorage
{
    public Task<bool> insertNewUser(string email, string password);
    public Task<string> selectPasswordByEmail(string email);
    public Task<string> selectIdByEmail(string email);

    Task<int> selectRoleById(string userId);
}