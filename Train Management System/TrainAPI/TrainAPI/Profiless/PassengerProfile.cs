using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Models;

namespace TrainAPI.Profiles
{
    public class PassengerProfile : Profile
    {
        public PassengerProfile()
        {
            CreateMap<PassengerCreateDTO, Passenger>();
            CreateMap<Passenger, PassengerReadDTO>();
        }
    }
}
