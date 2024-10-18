using API.Data;
using API.Models;
using API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly APIDbContext _context;

        public TicketController(APIDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetAllTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(AddTicketDTO request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null");
            }

            var domainModelTicket = new Ticket
            {
                Description = request.Description,
                Status = request.Status,
                Date = request.Date
            };

            await _context.Tickets.AddAsync(domainModelTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllTickets), new { id = domainModelTicket.Id }, domainModelTicket);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, UpdateTicketDTO request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null");
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound($"Ticket with ID {id} not found.");
            }

            // Update the properties
            ticket.Description = request.Description;
            ticket.Status = request.Status;
            ticket.Date = request.Date;

            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound($"Ticket with ID {id} not found.");
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}
