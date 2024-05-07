using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozy_Zad_dom.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
