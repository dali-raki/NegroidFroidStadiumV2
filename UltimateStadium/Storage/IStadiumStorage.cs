using BlazorApp1.Domain;

namespace UltimateStadium.Storage;

public interface IStadiumStorage
{
    public Task<List<Stadium>> selectAllStadiums();

    public Task<bool> insertNewStadium(string stadiumName,string stadiumPlace,double stadiumPrice);

    public  Task DeleteStadium(Guid stadiumId);
    public Task<bool>Favorite(Guid stadiumId);
    public Task<List<Stadium>> GetFavoriteStadiums();

    public Task<bool> updateStadium(string stadiumId,Stadium stadium);
}