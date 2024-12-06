using BlazorApp1.Domain;

using UltimateStadium.Storage.UserStorage;

namespace UltimateStadium.Services.UserServie;

public class UserService:IUserService
{
    private IUserStorage userStorage;
    public UserService(IUserStorage storage)
    {
        userStorage = storage;
    }
    
    public async Task<bool> createNewUser(string email, string password)
    {
        try
        {
            return await userStorage.insertNewUser(email, password);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }
        
    }


    public async Task<User> login(string email,string password)
    {
        try
        {
            var fetchedPass= await userStorage.selectPasswordByEmail(email);
            if (password.Equals(fetchedPass)) 
            {
                var userId = await userStorage.selectIdByEmail(email);
                int role = await userStorage.selectRoleById(userId);
                
                return new User(){email = email,id = userId,role = role};
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }

        return null;
    }
}