using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace UltimateStadium.Storage;

public class DashBoardStorage:IDashBoardStorage
{
    private readonly string connectionString;

    public DashBoardStorage(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("Negroid");
    }

    private readonly string getManagersCountQuery = "select count(*) from users where role=@role";
    private readonly string getUserCountQuery = "select count(*) from users where role=@role";
    private readonly string getStadiumsCountQuery = "select count (*) from stadiums ";
    
    
    public async Task<int> selectManagersCount()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(getManagersCountQuery,connection);
                await connection.OpenAsync();
                command.Parameters.AddWithValue("role", 2);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    return (int) table.Rows[0][0];
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

 
    }

    public async Task<int> selectStadiumsCount()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(getStadiumsCountQuery,connection);
                await connection.OpenAsync();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    return (int) table.Rows[0][0];
                }
                else 
                {
                    return 0;
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }

    public async Task<int> selectUsersCount()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(getUserCountQuery,connection);
                await connection.OpenAsync();
                command.Parameters.AddWithValue("role", 3);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    return (int) table.Rows[0][0];
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }
}