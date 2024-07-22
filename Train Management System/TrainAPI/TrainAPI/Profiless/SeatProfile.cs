using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Models;

namespace TrainAPI.Profiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<SeatCreateDTO, Seat>();
            CreateMap<Seat, SeatReadDTO>();
        }
    }
}
