

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
        var TicketToCreate = _mapper.Map<Ticket>(createTicketDto);
        await _dbContext.Tickets.AddAsync(TicketToCreate);
        await _dbContext.SaveChangesAsync();

        return Result.Success(HttpStatusCode.OK, "Tickets created");
    }

    public async Task<List<Ticket>> GetAllTickets()
    {
        try
        {
            var results = await _dbContext.Tickets.ToListAsync();
            return results;
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}