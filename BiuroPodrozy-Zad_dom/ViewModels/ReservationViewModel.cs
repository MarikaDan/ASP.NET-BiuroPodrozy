namespace BiuroPodrozy_Zad_dom.ViewModels
{
    public class ReservationViewModel
    {
        public int ReservationID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int TourID { get; set; }
        public int ClientID { get; set; }
    }
}
