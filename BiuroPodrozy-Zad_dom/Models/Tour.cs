namespace BiuroPodrozy_Zad_dom.Models
{
    public class Tour
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PricePerPerson { get; set; }
        public int NumberOfDays { get; set; }

        public string Photo { get; set; }
        public string Description { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
