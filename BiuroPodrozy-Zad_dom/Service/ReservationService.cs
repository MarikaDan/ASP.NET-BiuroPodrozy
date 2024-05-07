using AutoMapper;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.ViewModels;
using Humanizer;

namespace BiuroPodrozy_Zad_dom.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public IEnumerable<ReservationViewModel> GetAll()
        {
            var reservations = _reservationRepository.GetAll();
            var results = _mapper.Map<IEnumerable<ReservationViewModel>>(reservations);
            return results;
        }
        public ReservationViewModel GetById(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            var result = _mapper.Map<ReservationViewModel>(reservation);
            return result;
        }
        public bool Exists(int id)
        {
            return _reservationRepository.Exists(id);
        }
        public void Delete(int id)
        {
            _reservationRepository.Delete(id);
            _reservationRepository.Save();
        }
        public void Insert(ReservationViewModel reservationViewModel)
        {
            var reservation = _mapper.Map<Reservation>(reservationViewModel);
            _reservationRepository.Insert(reservation);
            _reservationRepository.Save();
        }
        public void Update(ReservationViewModel reservationViewModel)
        {
            var reservation = _mapper.Map<Reservation>(reservationViewModel);
            _reservationRepository.Update(reservation);
            _reservationRepository.Save();
        }
    }
}
