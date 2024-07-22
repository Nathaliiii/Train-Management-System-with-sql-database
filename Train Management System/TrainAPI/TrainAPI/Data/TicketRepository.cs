using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAPI.Data;
using TrainAPI.DTO;
using TrainAPI.Model;


namespace TrainAPI.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDBContext _context;

        public TicketRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<TicketReadDTO> GetTicketByIdAsync(int id)
        {
            var ticketEntity = await _context.tickets.FindAsync(id);
            return MapToTicketReadDTO(ticketEntity);
        }

        public async Task<IEnumerable<TicketReadDTO>> GetAllTicketsAsync()
        {
            var ticketEntities = await _context.tickets.ToListAsync();
            return ticketEntities.Select(MapToTicketReadDTO);
        }

        public async Task<int> CreateTicketAsync(TicketCreateDTO ticket)
        {
            var ticketEntity = MapToTicketEntity(ticket);
            _context.tickets.Add(ticketEntity);
            await _context.SaveChangesAsync();
            return ticketEntity.Id;
        }

        public async Task UpdateTicketAsync(int id, TicketCreateDTO ticket)
        {
            var ticketEntity = await _context.tickets.FindAsync(id);
            if (ticketEntity != null)
            {
                ticketEntity.Name = ticket.Name;
                ticketEntity.Price = ticket.Price;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticketEntity = await _context.tickets.FindAsync(id);
            if (ticketEntity != null)
            {
                _context.tickets.Remove(ticketEntity);
                await _context.SaveChangesAsync();
            }
        }

        private TicketReadDTO MapToTicketReadDTO(Ticket ticket)
{
    if (ticket == null)
    {
        // Handle null case appropriately, such as returning null or throwing an exception
        return null;
    }

    return new TicketReadDTO
    {
        Id = ticket.Id,
        Name = ticket.Name,
        Price = ticket.Price
    };
}


        private Ticket MapToTicketEntity(TicketCreateDTO ticket)
        {
            return new Ticket
            {
                Name = ticket.Name,
                Price = ticket.Price
            };
        }
    }
}
