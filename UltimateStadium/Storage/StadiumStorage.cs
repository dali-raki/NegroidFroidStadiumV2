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
    private readonly string UpdateFavoriteQuery = "UPDATE stadiums SET fa = 1 WHERE stadiumId = @stadiumId";
    private readonly string query = "SELECT * FROM stadiums WHERE fa = 1";

    private readonly string selectAllStadiumsQuery="select * from stadiums";
    private readonly string insertNewStadiumQuery="insert into stadiums (stadiumId,stadiumName,stadiumPlace,stadiumPrice,isReserved) values (@stadiumId,@stadiumName,@stadiumPlace,@stadiumPrice,@isReserved)";
    private readonly string deleteStadiumByIdQuery = "DELETE FROM stadiums WHERE stadiumId = @stadiumId;";
    private readonly string selectStadiumByIdQuery = "SELECT * from stadiums WHERE stadiumId = @StadiumId";
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
                    string favorite = row["fa"].ToString();
                    
                    stadiums.Add(new Stadium(stadiumId,stadiumName,stadiumPlace,stadiumPrice,isReserved,favorite));
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

    public async Task<bool> insertNewStadium(string stadiumName,string stadiumPlace,double stadiumPrice)
    {
        try
        {
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertNewStadiumQuery, connection);
                await connection.OpenAsync();
                command.Parameters.AddWithValue("stadiumId", Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("stadiumName", stadiumName);
                command.Parameters.AddWithValue("stadiumPlace", stadiumPlace);
                command.Parameters.AddWithValue("stadiumPrice", stadiumPrice);
                command.Parameters.AddWithValue("isReserved", false);
                return await command.ExecuteNonQueryAsync()>0;
               
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("Error Negroid 2");
        }
    }

 
            public async Task DeleteStadium(Guid stadiumId)
            {
                try
                {
                    await using (var connection = new SqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        var command = new SqlCommand(deleteStadiumByIdQuery, connection);
                        command.Parameters.AddWithValue("@stadiumId", stadiumId);

                        await command.ExecuteNonQueryAsync();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
               
            }

            public async Task<bool> Favorite(Guid stadiumId)
            {
                try
                {
                    await using var connection = new SqlConnection(connectionString); 
                    await connection.OpenAsync();

                    using var command = new SqlCommand(UpdateFavoriteQuery, connection);
                    command.Parameters.Add("@stadiumId", SqlDbType.UniqueIdentifier).Value = stadiumId;

                    return await command.ExecuteNonQueryAsync() > 0;         }
                catch (Exception ex)
                {
                    Console.WriteLine("error favorite {ex.Message}");
                    throw;
                }
            }

            public async Task<List<Stadium>> GetFavoriteStadiums()
            {
                List<Stadium> stadiums = new List<Stadium>();
                try
                {
                    await using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query,connection);
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
                            string favorite = row["fa"].ToString();
                    
                            stadiums.Add(new Stadium(stadiumId,stadiumName,stadiumPlace,stadiumPrice,isReserved,favorite));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error fetching favorite stadiums: {e.Message}");
                    throw;
                }
                
                return stadiums;
                }
                

                
            }


       
    
    
