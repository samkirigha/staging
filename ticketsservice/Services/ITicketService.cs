using ticketsservice.Dtos;
using ticketsservice.Models;

namespace ticketsservice.Services;

public interface ITicketService
{
    public Task<List<Ticket>> GetAllTickets();

    Task<Result> CreateTicket(CreateTicketDto createTicketDto);
}