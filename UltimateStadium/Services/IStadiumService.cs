using BlazorApp1.Domain;

namespace UltimateStadium.Services;

public interface IStadiumService
{
    public Task<List<Stadium>> getAllStadiums();
}