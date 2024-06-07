using BiuroPodrozy_Zad_dom.Data;
using BiuroPodrozy_Zad_dom.Models;
namespace BiuroPodrozy_Zad_dom.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly ReservationContext _context;
        public TourRepository(ReservationContext context)
        {
            _context = context;
        }
        public IQueryable<Tour> GetAll() 
        {
            return _context.Tours;
        }
        public Tour GetById(int TourId)
        {
            return _context.Tours.Find(TourId);
        }
        public void Insert(Tour tour)
        {
            _context.Tours.Add(tour);
        }
        public void Update(Tour tour)
        {
            _context.Entry(tour).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Delete(int TourId)
        {
            Tour tour = _context.Tours.Find(TourId);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(int id) => _context.Tours.Any(c => c.ID == id);

    }
}
