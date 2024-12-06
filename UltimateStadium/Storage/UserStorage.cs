using System.Data;
using BlazorApp1.Domain;
using Microsoft.Data.SqlClient;
using SQL;

namespace UltimateStadium.Storage.UserStorage;

public class UserStorage:IUserStorage
{
    private readonly string connectionString;
    public UserStorage(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("Negroid");
    }

    private string insertNewUserQuery = "insert into users (id,email,password) values (@id,@email,@password)";
    private string selectUserByEmailQuery = "select password from users  where email=@email";
    private string selectIdByEmailQuery = "select id from users  where email=@email";
    private string selectRoleByIdQuery = "select role from users  where id=@id";
    
    public async Task <bool> insertNewUser(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertNewUserQuery, con);
                await con.OpenAsync();
                command.Parameters.AddWithValue("id", Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("password", password);
                return command.ExecuteNonQuery()>0;
            }
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<string> selectPasswordByEmail(string email)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectUserByEmailQuery, con);
                command.Parameters.AddWithValue("email", email);
                await con.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
               
                if (dataTable.Rows.Count > 0)
                {
                   
                    var user = dataTable.Rows[0];
                    return user["password"].ToString();
                }

            }
        }
        catch (Exception e)
        {
            throw;
        }

        return null;
    }

    public async Task<string> selectIdByEmail(string email)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectIdByEmailQuery, con);
                await con.OpenAsync();
                command.Parameters.AddWithValue("email", email);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
               
                if (dataTable.Rows.Count > 0)
                {
                   
                    var user = dataTable.Rows[0];
                    return user["id"].ToString();
                }

            }
        }
        catch (Exception e)
        {
            throw;
        }

        return null;
    }

    public async Task<int> selectRoleById(string userId)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectRoleByIdQuery, con);
                await con.OpenAsync();
                command.Parameters.AddWithValue("id", userId);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
               
                if (dataTable.Rows.Count > 0)
                {
                   
                    var user = dataTable.Rows[0];
                    return (int) user["role"];
                }

            }
        }
        catch (Exception e)
        {
            throw;
        }

        return -1;
    }
}