namespace UltimateStadium.Components.Models.Reservationmodels
{
    public class ReservationModel
    {
        public string IdReservation { get; set; }
        public string IdUser { get; set; }
        public string IdStadium { get; set; }
        public DateOnly ReservationDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
