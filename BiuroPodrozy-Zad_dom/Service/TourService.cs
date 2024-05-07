using AutoMapper;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.ViewModels;
using System.Diagnostics.Metrics;

namespace BiuroPodrozy_Zad_dom.Service
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;

        public TourService(ITourRepository tourRepository, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public IEnumerable<TourViewModel> GetAll()
        {
            var tours = _tourRepository.GetAll();
            var results = _mapper.Map<IEnumerable<TourViewModel>>(tours);
            return results;
        }
        public TourViewModel GetById(int id)
        {
            var tour = _tourRepository.GetById(id);
            var result = _mapper.Map<TourViewModel>(tour);
            return result;
        }
        public bool Exists(int id)
        {
            return _tourRepository.Exists(id);
        }
        public void Delete(int id)
        {
            _tourRepository.Delete(id);
            _tourRepository.Save();
        }
        public void Insert(TourViewModel tourViewModel)
        {
            var tour = _mapper.Map<Tour>(tourViewModel);
            _tourRepository.Insert(tour);
            _tourRepository.Save();
        }
        public void Update(TourViewModel tourViewModel)
        {
            var tour = _mapper.Map<Tour>(tourViewModel);
            _tourRepository.Update(tour);
            _tourRepository.Save();
        }
    }
}
