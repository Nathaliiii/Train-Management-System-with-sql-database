using System.Collections.Generic;
using System.Threading.Tasks;
using TrainAPI.DTO;

namespace TrainAPI.Repositories
{
    public interface ITicketRepository
    {
        Task<TicketReadDTO> GetTicketByIdAsync(int id);
        Task<IEnumerable<TicketReadDTO>> GetAllTicketsAsync();
        Task<int> CreateTicketAsync(TicketCreateDTO ticket);
        Task UpdateTicketAsync(int id, TicketCreateDTO ticket);
        Task DeleteTicketAsync(int id);
    }
}
