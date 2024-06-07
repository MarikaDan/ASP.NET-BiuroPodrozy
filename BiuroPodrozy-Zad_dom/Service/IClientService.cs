using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace BiuroPodrozy_Zad_dom.Service
{
    public interface IClientService
    {
        IEnumerable<ClientViewModel> GetAll();
        ClientViewModel GetById(string id);
        bool Exists(string id);
        void Delete(string id);
        void Insert(ClientViewModel client);
        void Update(ClientViewModel client);
    }
}
