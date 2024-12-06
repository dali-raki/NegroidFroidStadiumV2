using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BlazorApp1.Domain;
using System;
using System.Data;
using System.Threading.Tasks;

namespace UltimateStadium.Storage
{
    public class UserStorage : IUserStorage
    {
        private readonly string connectionString;
        private readonly string selectUserByEmailAndPasswordQuery = "SELECT [id], [email], [password], [role] FROM [users] WHERE [email] = @Email AND [password] = @Password";
        private readonly string insertUserQuery = "INSERT INTO  [users] ([id],[email], [password], [role]) VALUES (@id,@Email, @Password, @Role)";

        public UserStorage(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Negroid");
        }

     
        public async Task<UserRole?> AuthenticateUser(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(selectUserByEmailAndPasswordQuery, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password); 
                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                       
                        return Enum.Parse<UserRole>(reader["role"].ToString());
                    }
                    else
                    {
                       
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error authenticating user");
            }
        }
        public async Task<bool> CreateAccount(string email, string password, UserRole role)
        {
            try
            {
             
               

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(insertUserQuery, connection);
                    command.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    int roleId = role switch
                    {
                        UserRole.Manager => 2,
                        UserRole.Client => 1,

                    };
                    command.Parameters.AddWithValue("@Role", roleId);

                    await connection.OpenAsync();

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error creating user account");
            }
        }
    
    }
}
