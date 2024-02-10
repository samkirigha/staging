

using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ticketsservice.Dtos;
using ticketsservice.EF;
using ticketsservice.Models;
using ticketsservice.Services;

namespace ticketsservice.services;

public class TicketService : ITicketService
{
    private TicketsDBContext _dbContext;
    private IMapper _mapper;

    public TicketService(TicketsDBContext ticketsDBContext, IMapper mapper)
    {
        _dbContext = ticketsDBContext;
        _mapper = mapper;
    }

    public async Task<Result> CreateTicket(CreateTicketDto createTicketDto)
    {
        try
        {
            var TicketToCreate = _mapper.Map<Ticket>(createTicketDto);
            await _dbContext.Tickets.AddAsync(TicketToCreate);
            await _dbContext.SaveChangesAsync();

            return Result.Success(HttpStatusCode.OK, "Ticket created");
        }
        catch (Exception ex)
        {
            return Result.Failed(HttpStatusCode.InternalServerError, $"Error: {ex.Message} - {ex.InnerException.Message} - {ex.StackTrace}.");
            throw;
        }
    }

    public async Task<Result> CreateTickets(IEnumerable<CreateTicketDto> tickets)
    {
        try
        {
            if (!tickets.Any()) throw new ArgumentException("Add atleast one ticket");
            var ticketsToCreates = _mapper.Map<IEnumerable<Ticket>>(tickets);
            await _dbContext.Tickets.AddRangeAsync(ticketsToCreates);
            await _dbContext.SaveChangesAsync();

            return Result.Success(HttpStatusCode.OK, "Tickets created");
        }
        catch (Exception ex)
        {
            return Result.Failed(HttpStatusCode.InternalServerError, $"Error: {ex.Message} - {ex.InnerException.Message} - {ex.StackTrace}.");
            throw;
        }
    }

    public async Task<Result> DeleteTicket(Guid ticketId)
    {
        try
        {
            var existingTicket = await _dbContext.Tickets.Where(t => (bool)!t.isDeleted).Where(t => t.TicketID == ticketId).FirstOrDefaultAsync();
            if (existingTicket == null)
                return Result.Success(HttpStatusCode.NotFound, "Ticket not found");

            existingTicket.isDeleted = true;

            await _dbContext.SaveChangesAsync();

            return Result.Success(HttpStatusCode.OK, "Ticket Deleted");

        }
        catch (Exception ex)
        {
            return Result.Failed(HttpStatusCode.InternalServerError, $"Error: {ex.Message} - {ex.InnerException.Message} - {ex.StackTrace}.");
            throw;
        }
    }

    public async Task<List<TicketResponseDto>> GetAllTickets()
    {
        try
        {
            var response = await _dbContext.Tickets.ToListAsync();
            var resultsReturned = _mapper.Map<List<TicketResponseDto>>(response);
            return resultsReturned;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public async Task<Result<TicketResponseDto>> GetSingleTicketById(Guid ticketId)
    {
        try
        {
            var ticket = await _dbContext.Tickets.Where(t => t.TicketID == ticketId).FirstOrDefaultAsync();
            if (ticket is null)
            {
                return Result<TicketResponseDto>.Failed(HttpStatusCode.NotFound, "Ticket not found");
            }
            var result = _mapper.Map<TicketResponseDto>(ticket);
            return Result<TicketResponseDto>.Success(HttpStatusCode.OK, result);
        }
        catch (Exception ex)
        {
            return Result<TicketResponseDto>.Failed(HttpStatusCode.InternalServerError, $"Error: {ex.Message} - {ex.InnerException.Message} - {ex.StackTrace}.");
            throw;
        }
    }

    public async Task<Result<CreateTicketDto>> UpdateTicket(Guid TicketId, CreateTicketDto updatedTicket)
    {
        try
        {
            var ticketToUpdate = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.TicketID == TicketId);
            if (ticketToUpdate is null)
            {
                return Result<CreateTicketDto>.Failed(HttpStatusCode.NotFound, "Ticket not found");
            }

            ticketToUpdate.TicketNumber = updatedTicket.TicketNumber;

            _dbContext.Tickets.Update(ticketToUpdate);
            await _dbContext.SaveChangesAsync();

            return Result<CreateTicketDto>.Success(HttpStatusCode.OK, updatedTicket);
        }
        catch (Exception ex)
        {
            return Result<CreateTicketDto>.Failed(HttpStatusCode.InternalServerError, $"Error: {ex.Message} - {ex.InnerException.Message} - {ex.StackTrace}.");
            throw;
        }
    }
}