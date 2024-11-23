using BlazorApp1.Domain;

namespace UltimateStadium.Storage;

public interface IStadiumStorage
{
    public Task<List<Stadium>> selectAllStadiums();
}