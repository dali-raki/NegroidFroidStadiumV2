using UltimateStadium.Components.Models.Staduimmodels;

namespace UltimateStadium.Components.Pages
{
    public class Home
    {
         List<StaduimModel> Items = new List<StaduimModel>();

         StaduimModel s = new StaduimModel()
        {
            stadiumId = Guid.NewGuid().ToString(),
            stadiumName = "Test1",
            stadiumPlace = "test1",
            stadiumRentalPrice = 000
        };

        StaduimModel s2 = new StaduimModel()
        {
            stadiumId = Guid.NewGuid().ToString(),
            stadiumName = "Test2",
            stadiumPlace = "test2",
            stadiumRentalPrice = 1000
        };

        StaduimModel s3= new StaduimModel()
        {
            stadiumId = Guid.NewGuid().ToString(),
            stadiumName = "Test3",
            stadiumPlace = "test3",
            stadiumRentalPrice = 2000
        };

        StaduimModel s4 = new StaduimModel()
        {
            stadiumId = Guid.NewGuid().ToString(),
            stadiumName = "Test4",
            stadiumPlace = "test4",
            stadiumRentalPrice = 3000
        };

        public Home()
        {
            Items.Add(s);
            Items.Add(s2);
            Items.Add(s3);
            Items.Add(s4);
        }
    }
}
