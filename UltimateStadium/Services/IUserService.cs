using UltimateStadium.Domain;

namespace UltimateStadium.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllManagers();
    }
}
