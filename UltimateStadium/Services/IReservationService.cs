using UltimateStadium.Domain;

namespace UltimateStadium.Services;

public interface IReservationService
{
    Task<bool> InsertReservation(Reservation reservation);
    Task<Reservation> SelectReservationById(string reservationId);
    Task<List<Reservation>> SelectAllReservations();
    Task<bool> UpdateReservation(Reservation reservation);
    Task<bool> DeleteReservation(string reservationId);
    Task<int> GetTotalReservationsByStadiumAndMonth(string stadiumId, int year, int month);
    Task<int> GetTotalReservationsByMonthAndYearAsync(int year, int month);
}
