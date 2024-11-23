using BlazorApp1.Domain;
using UltimateStadium.Storage;

namespace UltimateStadium.Services;

public class StadiumService : IStadiumService
{
    private readonly IStadiumStorage stadiumService;

    public StadiumService(IStadiumStorage stadiumService)
    {
        this.stadiumService = stadiumService;
    }
    
    public async Task<List<Stadium>> getAllStadiums()
    {
        try
        {
            return await stadiumService.selectAllStadiums();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}