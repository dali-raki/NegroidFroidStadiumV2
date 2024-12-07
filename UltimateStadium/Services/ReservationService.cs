using Microsoft.AspNetCore.Components;
using UltimateStadium.Domain;
namespace UltimateStadium.Services
{
    public class ReservationService : IReservationService
    {
        [Inject] UltimateStadium.Storage.IReservationStorage Storage { get; set; }


        public async Task<bool> CreateReservation(Reservation reservation)
        {
            return await Storage.InsertReservation(reservation);
        }


        public async Task<Reservation> GetReservationById(string reservationId)
        {
            return await Storage.SelectReservationById(reservationId);
        }

        public async Task<List<Reservation>> GetAllReservations() => await Storage.SelectAllReservations();


        public async Task<bool> SetReservation(Reservation reservation)
        {
            return await Storage.UpdateReservation(reservation);
        }

      /*  public async Task<bool> RemoveReservation(string reservationId)
        {
            return Storage.DeleteReservation(reservationId);
        }*/

        public async Task<int> GetTotalReservationsByStadiumAndMonth(string stadiumId, int year, int month)
        {
            return await Storage.GetTotalReservationsByStadiumAndMonth(stadiumId, year, month);
        }


        public async Task<int> GetTotalReservationsByMonthAndYearAsync(int year, int month)
        {
            return await Storage.GetTotalReservationsByMonthAndYearAsync((int)year, month);
        }

    }
}
