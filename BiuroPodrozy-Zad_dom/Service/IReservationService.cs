using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace BiuroPodrozy_Zad_dom.Service
{
    public interface IReservationService
    {
        IEnumerable<ReservationViewModel> GetAll();
        ReservationViewModel GetById(int id);
        bool Exists(int id);
        void Delete(int id);
        void Insert(ReservationViewModel reservation);
        void Update(ReservationViewModel reservation);
    }
}
