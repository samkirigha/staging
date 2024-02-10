using ticketsservice.Dtos;
using ticketsservice.Models;

namespace ticketsservice.Services;

public interface ITicketService
{
    public Task<List<TicketResponseDto>> GetAllTickets();
    public Task<Result> CreateTickets(IEnumerable<CreateTicketDto> tickets);
    public Task<Result<TicketResponseDto>> GetSingleTicketById(Guid ticketId);
    Task<Result> CreateTicket(CreateTicketDto createTicketDto);
    Task<Result<CreateTicketDto>> UpdateTicket(Guid TicketId, CreateTicketDto updatedCustomer);
    Task<Result> DeleteTicket(Guid ticketId);
}