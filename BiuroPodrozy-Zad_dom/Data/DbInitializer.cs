using BiuroPodrozy_Zad_dom.Models;
using System.Diagnostics.Metrics;

namespace BiuroPodrozy_Zad_dom.Data
{
    public class DbInitializer
    {
        public static void Initialize(ReservationContext context)
        {
            if (context.Clients.Any())
            {
                return;
            }
            var clients = new Client[]
            {
                new Client{FirstName="Mikołaj",LastName="Zuziak",Email="pterodaktyl@poczta.pl",PhoneNumber="997"},
                new Client{FirstName="Jakub",LastName="Lasota",Email="niezdalemboio@poczta.pl",PhoneNumber="000000000"},
                new Client{FirstName="Jakub",LastName="Janik",Email="kokszsilowni@poczta.pl",PhoneNumber="111222333"},
                new Client{FirstName="Marika",LastName="Daniszewska",Email="barbigerl@poczta.pl",PhoneNumber="444555666"}
            };
            foreach(Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();
            var tours = new Tour[]
            {
                new Tour{Country="Chorwacja",City = "Rabac",PricePerPerson = "1200zł",NumberOfDays = 3,Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2020/6/4/d1/26168098.jpg",Description ="Wyjedź do ciepłego, słonecznego kraju i pozwiedzaj piękny Rabac!"},
                new Tour{Country = "Chorwacja",City = "Orebic",PricePerPerson = "1900zł",NumberOfDays = 5,Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2021/9/22/d5/31052888.jpg",Description ="Wypocznij w przepięknej Chorwacji! W Orebicu czeka cię dużo atrakcji!"},
                new Tour{Country = "Hiszpania",City = "Costa Del Sol",PricePerPerson = "1300zł",NumberOfDays = 3,Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2021/4/8/d48/28186183.jpg",Description ="Costa Del Sol - piękne miasto pełne atrakcji. Możesz tam być już teraz!"},
                new Tour{ Country = "Hiszpania",City = "Majorka",PricePerPerson = "1300zł",NumberOfDays = 4,Photo="https://dcontent.inviacdn.net/shared/img/web-1200x1024/2020/2/10/d42/24213358.jpg",Description ="Czy może być coś lepszego niż Majorka? Wyjedź w najbliższy weekend i ciesz się plażą!"}
            };
            foreach( Tour t in tours) 
            {
                context.Tours.Add(t);
            }
            context.SaveChanges();
            var reservations = new Reservation[]
            {
                new Reservation{ClientID=1,TourID=1, TotalPrice=2000, PaymentDate=DateTime.Parse("06.25.2020"), From=DateTime.Parse("08.20.2020"), To=DateTime.Parse("08.30.2020")},
                new Reservation{ClientID=2,TourID=4, TotalPrice=3000, PaymentDate=DateTime.Parse("03.12.2020"), From=DateTime.Parse("09.15.2020"), To=DateTime.Parse("09.30.2020")},
                new Reservation{ClientID=3, TourID=2, TotalPrice=4500, PaymentDate=DateTime.Parse("01.01.2020"), From=DateTime.Parse("06.01.2020"), To=DateTime.Parse("06.08.2020")},
                new Reservation{ClientID=4,TourID=3, TotalPrice=4000, PaymentDate=DateTime.Parse("02.07.2020"), From=DateTime.Parse("07.02.2020"), To=DateTime.Parse("07.12.2020")}
            };
            foreach(Reservation r in reservations ) 
            {
                context.Reservations.Add(r);
            }
            context.SaveChanges();
        }
    }
}
