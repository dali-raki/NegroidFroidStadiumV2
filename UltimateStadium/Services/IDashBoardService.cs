namespace UltimateStadium.Services;

public interface IDashBoardService
{
    public Task<int> getManagersCount();
    public Task<int> getStadiumsCount();
    public Task<int> getUsersCount();
}