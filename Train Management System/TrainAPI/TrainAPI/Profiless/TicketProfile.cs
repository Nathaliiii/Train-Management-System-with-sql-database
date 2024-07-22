using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Model;

namespace TrainAPI.MappingProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketReadDTO>(); // Map Ticket entity to TicketReadDTO
            CreateMap<TicketCreateDTO, Ticket>(); // Map TicketCreateDTO to Ticket entity
        }
    }
}
