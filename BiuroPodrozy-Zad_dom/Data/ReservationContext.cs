using BiuroPodrozy_Zad_dom.Models;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozy_Zad_dom.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options) { }
        public ReservationContext() { }

        public DbSet<Reservation> Reservations { get; set;}
        public DbSet<Client> Clients { get; set;}
        public DbSet<Tour> Tours { get; set;}

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Reservation>().ToTable("Reservation");
            modelbuilder.Entity<Client>().ToTable("Client");
            modelbuilder.Entity<Tour>().ToTable("Tour");
        }
    }
}
