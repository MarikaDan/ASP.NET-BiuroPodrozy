using AutoMapper;
using BiuroPodrozy_Zad_dom.Models;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace Trips.DAL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();

            CreateMap<Reservation, ReservationViewModel>();
            CreateMap<ReservationViewModel, Reservation>();

            CreateMap<Tour, TourViewModel>();
            CreateMap<TourViewModel, Tour>();
        }
    }
}