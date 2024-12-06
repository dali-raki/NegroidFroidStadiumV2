namespace UltimateStadium.Domain
{
    public class Reservation
    {

        public string IdReservation { get; set; } 
        public string IdUser { get; set; }        
        public string IdStadium { get; set; }     
        public DateTime ReservationDate { get; set; } 
        public TimeSpan StartTime { get; set; }   
        public TimeSpan EndTime { get; set; }    
    }

}
