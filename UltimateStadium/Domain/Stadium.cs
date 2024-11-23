namespace BlazorApp1.Domain;

public class Stadium
{
    public string stadiumId { get; set; }
    public string stadiumName { get; set; }
    public string stadiumPlace { get; set; }
    public double stadiumRentalPrice { get; set; }
    public bool isRented { get; set; }

    public Stadium(string stadiumId, string stadiumName, string stadiumPlace, double stadiumRentalPrice, bool isRented)
    {
        this.stadiumId = stadiumId;
        this.stadiumName = stadiumName;
        this.stadiumPlace = stadiumPlace;
        this.stadiumRentalPrice = stadiumRentalPrice;
        this.isRented = isRented;
    }
}