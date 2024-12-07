using UltimateStadium.Domain;

namespace UltimateStadium.Services
{
    public interface IReservationService
    {
        public Task<bool> CreateReservation(Reservation reservation);

        public Task<Reservation> GetReservationById(string reservationId);

        public Task<List<Reservation>> GetAllReservations();

        public Task<bool> SetReservation(Reservation reservation);

        public Task<int> GetTotalReservationsByStadiumAndMonth(string stadiumId, int year, int month);

        public Task<int> GetTotalReservationsByMonthAndYearAsync(int year, int month);
    }
}
