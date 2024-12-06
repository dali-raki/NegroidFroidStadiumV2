using Microsoft.Data.SqlClient;
using UltimateStadium.Domain;

namespace UltimateStadium.Storage
{
    public class UserStorage : IUserStorage
    {
        private readonly string connectionString;
        public UserStorage(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Negroid");
        }

        private readonly string selectAllManagers = "SELECT * FROM users where role=2";

        public async Task<List<User>> SelectAllManagers()
        {
            List<User> users = new List<User>();
            try
            {
                await using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(selectAllManagers, connection);
                    await connection.OpenAsync();

                    // Use SqlDataReader for better async support
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string usersId = reader.GetString(reader.GetOrdinal("id"));
                            string usersEmail = reader.GetString(reader.GetOrdinal("email"));
                            string usersPass = reader.GetString(reader.GetOrdinal("password"));
                            int usersRole = reader.GetInt32(reader.GetOrdinal("role"));

                            users.Add(new User(usersId, usersEmail, usersPass, usersRole));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Optionally log or rethrow the exception
            }

            return users;
        }
    }
}
