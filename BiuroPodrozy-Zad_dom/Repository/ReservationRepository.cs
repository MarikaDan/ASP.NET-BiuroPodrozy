using BiuroPodrozy_Zad_dom.Data;
using BiuroPodrozy_Zad_dom.Models;
namespace BiuroPodrozy_Zad_dom.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;
        public ReservationRepository(ReservationContext context)
        {
            _context = context;
        }
        public IQueryable<Reservation> GetAll() 
        {
            return _context.Reservations;
        }
        public Reservation GetById(int ReservationId)
        {
            return _context.Reservations.Find(ReservationId);
        }
        public void Insert(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
        }
        public void Update(Reservation reservation)
        {
            _context.Entry(reservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Delete(int ReservationId)
        {
            Reservation reservation = _context.Reservations.Find(ReservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(int id) => _context.Reservations.Any(c => c.ReservationID == id);

    }
}
