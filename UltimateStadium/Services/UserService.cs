using Microsoft.AspNetCore.Identity;
using UltimateStadium.Domain;
using UltimateStadium.Storage;
namespace UltimateStadium.Services
{
    public class UserService : IUserService
    {
        private readonly IUserStorage userStorage;
        public UserService(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        public async Task<List<User>> GetAllManagers()
        {

            try
            {
                return await this.userStorage.SelectAllManagers();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
