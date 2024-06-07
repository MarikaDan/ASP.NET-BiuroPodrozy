using AutoMapper;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.ViewModels;
namespace BiuroPodrozy_Zad_dom.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientViewModel> GetAll() 
        {
            var clients = _clientRepository.GetAll();
            var results = _mapper.Map<IEnumerable<ClientViewModel>>(clients);
            return results;
        }
        public ClientViewModel GetById(string id)
        {
            var client = _clientRepository.GetById(id);
            var result = _mapper.Map<ClientViewModel>(client);
            return result;
        }
        public bool Exists(string id)
        {
            return _clientRepository.Exists(id);
        }
        public void Delete(string id) 
        {
            _clientRepository.Delete(id);
            _clientRepository.Save();
        }
        public void Insert(ClientViewModel clientViewModel)
        {
            var client = _mapper.Map<Client>(clientViewModel);
            _clientRepository.Insert(client);
            _clientRepository.Save();
        }
        public void Update(ClientViewModel clientViewModel)
        {
            var client = _mapper.Map<Client>(clientViewModel);
            _clientRepository.Update(client);
            _clientRepository.Save();
        }
    }
}
