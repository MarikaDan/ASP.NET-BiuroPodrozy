using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace BiuroPodrozy_Zad_dom.Service
{
    public interface IClientService
    {
        IEnumerable<ClientViewModel> GetAll();
        ClientViewModel GetById(int id);
        bool Exists(int id);
        void Delete(int id);
        void Insert(ClientViewModel client);
        void Update(ClientViewModel client);
    }
}
