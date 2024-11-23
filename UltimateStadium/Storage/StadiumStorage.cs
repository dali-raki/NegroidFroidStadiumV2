using System.Data;
using BlazorApp1.Domain;
using Microsoft.Data.SqlClient;
using SQL;

namespace UltimateStadium.Storage;

public class StadiumStorage : IStadiumStorage
{
    public StadiumStorage(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("Negroid");
    }

    private readonly string connectionString;
    
    private readonly string selectAllStadiumsQuery="select * from stadiums";
    public async Task<List<Stadium>> selectAllStadiums()
    {
        List<Stadium> stadiums = new List<Stadium>();
        
        try
        {
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectAllStadiumsQuery,connection);
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
                foreach(DataRow row in dataTable.Rows)
                {
                    string stadiumId = row["stadiumId"].ToString();
                    string stadiumName = row["stadiumName"].ToString();
                    string stadiumPlace = row["stadiumPlace"].ToString();
                    double stadiumPrice = (double)row["stadiumPrice"];
                    bool isReserved = ((byte)row["isReserved"])== 1;
                    
                    stadiums.Add(new Stadium(stadiumId,stadiumName,stadiumPlace,stadiumPrice,isReserved));
                }
            }
            return stadiums;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("Error Negroid");

        }

        return null;
    }
}