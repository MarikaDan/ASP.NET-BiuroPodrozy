using BiuroPodrozy_Zad_dom.Models;
namespace BiuroPodrozy_Zad_dom.Repository
{
    public interface ITourRepository
    {
        IQueryable<Tour> GetAll();
        Tour GetById(int TourId);
        void Insert(Tour tour);
        void Update(Tour tour);
        void Delete(int TourId);
        void Save();
        bool Exists(int id);
    }
}
