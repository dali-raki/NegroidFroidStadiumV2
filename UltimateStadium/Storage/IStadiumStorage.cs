using BlazorApp1.Domain;

namespace UltimateStadium.Storage;

public interface IStadiumStorage
{
    public Task<List<Stadium>> selectAllStadiums();

    public Task<bool> insertNewStadium(string stadiumName,string stadiumPlace,double stadiumPrice);

    public  Task DeleteStadium(Guid stadiumId);
}