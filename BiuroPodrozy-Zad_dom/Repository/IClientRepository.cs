using BiuroPodrozy_Zad_dom.Models;
namespace BiuroPodrozy_Zad_dom.Repository
{
    public interface IClientRepository
    {
        IQueryable<Client> GetAll();
        Client GetById(int ClientId);
        void Insert(Client client);
        void Update(Client client);
        void Delete(int ClientId);
        void Save();
        bool Exists(int id);
    }
}
