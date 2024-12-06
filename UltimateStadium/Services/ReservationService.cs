using UltimateStadium.Domain;
using UltimateStadium.Storage.ReservationStorage;

namespace UltimateStadium.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationStorage reservationStorage;

    public ReservationService(IReservationStorage reservationStorage)
    {
        this.reservationStorage = reservationStorage;
    }

    public async Task<bool> InsertReservation(Reservation reservation)
    {
        try
        {
            return await reservationStorage.InsertReservation(reservation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Reservation> SelectReservationById(string reservationId)
    {
        try
        {
            return await reservationStorage.SelectReservationById(reservationId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<List<Reservation>> SelectAllReservations()
    {
        try
        {
            return await reservationStorage.SelectAllReservations();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateReservation(Reservation reservation)
    {
        try
        {
            return await reservationStorage.UpdateReservation(reservation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteReservation(string reservationId)
    {
        try
        {
            return await reservationStorage.DeleteReservation(reservationId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<int> GetTotalReservationsByStadiumAndMonth(string stadiumId, int year, int month)
    {
        try
        {
            return await reservationStorage.GetTotalReservationsByStadiumAndMonth(stadiumId, year, month);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<int> GetTotalReservationsByMonthAndYearAsync(int year, int month)
    {
        try
        {
            return await reservationStorage.GetTotalReservationsByMonthAndYearAsync(year, month);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
