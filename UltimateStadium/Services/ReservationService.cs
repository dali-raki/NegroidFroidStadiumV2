using Microsoft.AspNetCore.Components;
using UltimateStadium.Domain;
using UltimateStadium.Storage;

namespace UltimateStadium.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationStorage Storage;
        public ReservationService(IReservationStorage stadiumStorage)
        {
            this.Storage = stadiumStorage;
        }

        public async Task<bool> CreateReservation(Reservation reservation)
        {
            if (Storage == null)
            {
                Console.WriteLine("Storage is null");
                return false;
            }

            try
            {
                // Proceed with reservation logic
                return await Storage.InsertReservation(reservation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
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
