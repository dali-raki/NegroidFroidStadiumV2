using UltimateStadium.Domain;

namespace UltimateStadium.Storage
{
    public interface IUserStorage
    {
        public Task<List<User>> SelectAllManagers();
    }
}
