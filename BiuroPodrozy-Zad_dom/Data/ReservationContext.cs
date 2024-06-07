using BiuroPodrozy_Zad_dom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BiuroPodrozy_Zad_dom.Data
{
    public class ReservationContext : IdentityDbContext<Client>
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<Reservation>().ToTable("Reservation");
            modelbuilder.Entity<Client>().ToTable("Client");
            modelbuilder.Entity<Tour>().ToTable("Tour");

            modelbuilder.Entity<Client>().HasKey(x => x.Id);
        }
    }
}
