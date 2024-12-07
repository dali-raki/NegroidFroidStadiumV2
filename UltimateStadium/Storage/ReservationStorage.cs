using Microsoft.Data.SqlClient;
using UltimateStadium.Domain;
namespace UltimateStadium.Storage
{
    public class ReservationStorage : IReservationStorage
    {
        private readonly string connectionString;

        public ReservationStorage(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Negroid");
        }

        private string insertReservationQuery = @"
        INSERT INTO Reservation (IdReservation, IdUser, IdStadium, ReservationDate, StartTime, EndTime) 
        VALUES (@IdReservation, @IdUser, @IdStadium, @ReservationDate, @StartTime, @EndTime)";
        private string selectAllReservationsQuery = "SELECT * FROM Reservation";
        private string selectReservationByIdQuery = "SELECT * FROM Reservation WHERE IdReservation = @IdReservation";
        private string updateReservationQuery = @"
        UPDATE Reservation 
        SET IdUser = @IdUser, IdStadium = @IdStadium, ReservationDate = @ReservationDate, 
            StartTime = @StartTime, EndTime = @EndTime 
        WHERE IdReservation = @IdReservation";
        private string deleteReservationQuery = "DELETE FROM Reservation WHERE IdReservation = @IdReservation";

        public async Task<bool> InsertReservation(Reservation reservation)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(insertReservationQuery, con);
                    command.Parameters.AddWithValue("IdReservation", Guid.NewGuid().ToString());
                    command.Parameters.AddWithValue("IdUser", reservation.IdUser);
                    command.Parameters.AddWithValue("IdStadium", reservation.IdStadium);
                    command.Parameters.AddWithValue("ReservationDate", reservation.ReservationDate);
                    command.Parameters.AddWithValue("StartTime", reservation.StartTime);
                    command.Parameters.AddWithValue("EndTime", reservation.EndTime);

                    await con.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Reservation> SelectReservationById(string idReservation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(selectReservationByIdQuery, con);
                    command.Parameters.AddWithValue("IdReservation", idReservation);

                    await con.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToReservation(reader);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        public async Task<bool> UpdateReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(updateReservationQuery, con);
                    command.Parameters.AddWithValue("IdReservation", reservation.IdReservation);
                    command.Parameters.AddWithValue("IdUser", reservation.IdUser);
                    command.Parameters.AddWithValue("IdStadium", reservation.IdStadium);
                    command.Parameters.AddWithValue("ReservationDate", reservation.ReservationDate);
                    command.Parameters.AddWithValue("StartTime", reservation.StartTime);
                    command.Parameters.AddWithValue("EndTime", reservation.EndTime); ;

                    await con.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteReservation(string idReservation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(deleteReservationQuery, con);
                    command.Parameters.AddWithValue("IdReservation", idReservation);

                    await con.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Reservation>> SelectAllReservations()
        {
            var reservations = new List<Reservation>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(selectAllReservationsQuery, con);
                    await con.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reservations.Add(MapReaderToReservation(reader));
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return reservations;
        }
        public async Task<int> GetTotalReservationsByStadiumAndMonth(string stadiumId, int year, int month)
        {
            string query = @"
        SELECT 
            COUNT(*) AS TotalReservations
        FROM 
            Reservation
        WHERE 
            IdStadium = @IdStadium
            AND YEAR(ReservationDate) = @Year
            AND MONTH(ReservationDate) = @Month;";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // Ajouter les paramètres
                        command.Parameters.AddWithValue("@IdStadium", stadiumId);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Month", month);

                        // Exécuter la requête
                        object result = await command.ExecuteScalarAsync();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching total reservations by stadium and month.", ex);
            }
        }


        public async Task<int> GetTotalReservationsByMonthAndYearAsync(int year, int month)
        {
            string query = @"
        SELECT 
            COUNT(*) AS TotalReservations
        FROM 
            Reservation
        WHERE 
            YEAR(ReservationDate) = @Year
            AND MONTH(ReservationDate) = @Month;";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // Ajouter les paramètres
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Month", month);

                        var result = await command.ExecuteScalarAsync();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching total reservations by month and year.", ex);
            }
        }


        private Reservation MapReaderToReservation(SqlDataReader reader)
        {
            return new Reservation
            {
                IdReservation = reader["IdReservation"].ToString(),
                IdUser = reader["IdUser"].ToString(),
                IdStadium = reader["IdStadium"].ToString(),
                ReservationDate = Convert.ToDateTime(reader["ReservationDate"]),
                StartTime = TimeSpan.Parse(reader["StartTime"].ToString()),
                EndTime = TimeSpan.Parse(reader["EndTime"].ToString())
            };
        }
    }
}
