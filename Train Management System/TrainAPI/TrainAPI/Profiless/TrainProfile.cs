using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Models;

namespace TrainAPI.Profiles
{
    public class TrainProfile : Profile
    {
        public TrainProfile()
        {
            CreateMap<TrainCreateDTO, Train>();
            CreateMap<Train, TrainReadDTO>();
        }
    }
}

