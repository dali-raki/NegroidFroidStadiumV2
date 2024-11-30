using UltimateStadium.Storage;

namespace UltimateStadium.Services;

public class DashBoardService:IDashBoardService
{
    private readonly IDashBoardStorage dashBoardStorage;
    public DashBoardService(IDashBoardStorage dashBoardStorage)
    {
        this.dashBoardStorage = dashBoardStorage;
    }
    public async Task<int> getManagersCount()
    {
        try
        {
            return await dashBoardStorage.selectManagersCount();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }
    }

    public async Task<int> getStadiumsCount()
    {
        try
        {
            return await dashBoardStorage.selectStadiumsCount();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }
    }

    public async Task<int> getUsersCount()
    {
        try
        {
            return await dashBoardStorage.selectUsersCount();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }
    }
}