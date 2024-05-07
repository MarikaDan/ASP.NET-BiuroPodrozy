using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace BiuroPodrozy_Zad_dom.Service
{
    public interface ITourService
    {
        IEnumerable<TourViewModel> GetAll();
        TourViewModel GetById(int id);
        bool Exists(int id);
        void Delete(int id);
        void Insert(TourViewModel tour);
        void Update(TourViewModel tour);
    }
}
