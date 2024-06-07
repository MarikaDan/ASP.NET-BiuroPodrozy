namespace BiuroPodrozy_Zad_dom.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PaymentDate {get; set;}
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int TourID { get; set; }
        public string ClientId { get; set; }
        public Tour Tour { get; set; }
        public Client Client { get; set; }
    }
}
