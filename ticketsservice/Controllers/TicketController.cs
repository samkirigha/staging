using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketsservice.Dtos;
using ticketsservice.EF;
using ticketsservice.Services;

namespace ticketsservice.Controllers
{
    [ApiController]
    [Route("/tickets")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets =  await _ticketService.GetAllTickets();
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketDto createTicketDto)
        {
            var result = await _ticketService.CreateTicket(createTicketDto);
            return Ok(result);
        }

        [HttpDelete("ticketId")]
        public async Task<IActionResult> DeleteTicket(Guid ticketId)
        {
            var result = await _ticketService.DeleteTicket(ticketId);
            return Ok(result);
        }

        [HttpPut("ticketId")]
        public async Task<IActionResult> UpdateTicket(Guid ticketId, CreateTicketDto createTicketDto)
        {
            var result = await _ticketService.UpdateTicket(ticketId, createTicketDto);
            return Ok(result);
        }
    }
}