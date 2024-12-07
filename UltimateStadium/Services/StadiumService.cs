using BlazorApp1.Domain;
using UltimateStadium.Storage;

namespace UltimateStadium.Services;

public class StadiumService : IStadiumService
{
    private readonly IStadiumStorage stadiumStorage;

    public StadiumService(IStadiumStorage stadiumStorage)
    {
        this.stadiumStorage = stadiumStorage;
    }

    public async Task<List<Stadium>> getAllStadiums()
    {
        try
        {
            return await stadiumStorage.selectAllStadiums();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<bool> addNewStadium(string stadiumName, string stadiumPlace, double stadiumPrice)
    {
        try
        {
            return await stadiumStorage.insertNewStadium(stadiumName, stadiumPlace, stadiumPrice);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task RemoveStadium(Guid stadiumId)
    {
        try
        {
            await stadiumStorage.DeleteStadium(stadiumId);
        }
        catch (Exception e) { }
    }
    public async Task<bool> Favorite(Guid stadiumId)
    {
        try
        {
            return await stadiumStorage.Favorite(stadiumId);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<Stadium>> getfav()
    {
        try
        {
            return await stadiumStorage.GetFavoriteStadiums();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public Task<bool> reserveStadium(DateTime from, DateTime to, double price, string stadiumId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> updatestadium(string stadiumId, Stadium newStadium)
    {
        throw new NotImplementedException();
    }
}