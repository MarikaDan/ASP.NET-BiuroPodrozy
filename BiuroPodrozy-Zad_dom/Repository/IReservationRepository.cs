using BiuroPodrozy_Zad_dom.Models;
namespace BiuroPodrozy_Zad_dom.Repository
{
    public interface IReservationRepository
    {
        IQueryable<Reservation> GetAll();
        Reservation GetById(int ReservationId);
        void Insert(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int ReservationId);
        void Save();
        bool Exists(int id);
    }
}
