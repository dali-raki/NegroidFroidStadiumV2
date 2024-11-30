namespace UltimateStadium.Storage;

public interface IDashBoardStorage
{
    public Task<int> selectManagersCount();
    public Task<int> selectStadiumsCount();
    public Task<int> selectUsersCount();
}