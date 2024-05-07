using BiuroPodrozy_Zad_dom.Data;
using BiuroPodrozy_Zad_dom.Models;
namespace BiuroPodrozy_Zad_dom.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ReservationContext _context;
        public ClientRepository(ReservationContext context)
        {
            _context = context;
        }
        public IQueryable<Client> GetAll() 
        {
            return _context.Clients;
        }
        public Client GetById(int ClientId)
        {
            return _context.Clients.Find(ClientId);
        }
        public void Insert(Client client)
        {
            _context.Clients.Add(client);
        }
        public void Update(Client client)
        {
            _context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Delete(int ClientId)
        {
            Client client = _context.Clients.Find(ClientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(int id) => _context.Clients.Any(c => c.ID == id);
        

    }
}
