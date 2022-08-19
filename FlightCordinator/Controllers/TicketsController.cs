using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightCordinator.Data;
using FlightCordinator.Models;
using FlightCordinator.DTO;

namespace FlightCordinator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly FCContext _context;

        public TicketsController(FCContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
          if (_context.Tickets == null)
          {
              return NotFound();
          }
            return await _context.Tickets.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDetailsDTO>> GetTicket(int id)
        {
          if (_context.Tickets == null)
          {
              return NotFound();
          }
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }
            var passenger = await _context.Passengers.FindAsync(ticket.PassengerId);
            var flight = await _context.Flights.FindAsync(ticket.FlightId);
            var pDto = new PassengerDTO
            {
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                Email = passenger.Email,
                Age = passenger.Age,
                Job = passenger.Job
            };
            var passengers = await _context.Passengers.Where(p => p.Tickets.Where(t => t.FlightId == flight.Id).Any()).ToListAsync();
            var fDto = new FlightDTO
            {
                Capacity = flight.Capacity,
                NumPassengers = passengers.Count(),
                Departure = flight.Departure,
                Arrival = flight.Arrival,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                FlightNumber = flight.FlightNumber,
            };
            var tDto = new TicketDetailsDTO
            {
                id = ticket.Id,
                PassengerId = ticket.PassengerId,
                Passenger = pDto,
                FlightId = ticket.FlightId,
                Flight = fDto
            };

            return Ok(tDto);
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketDTO dto)
        {
          if (_context.Tickets == null)
          {
              return Problem("Entity set 'FCContext.Tickets'  is null.");
          }
            var ticket = new Ticket(dto);
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
