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
    public class FlightsController : ControllerBase
    {
        private readonly FCContext _context;

        public FlightsController(FCContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
          if (_context.Flights == null)
          {
              return NotFound();
          }
            var flights = await _context.Flights.ToListAsync();
            foreach (var flight in flights)
            {
                var passengers = await _context.Tickets.Where(t => t.FlightId == flight.Id).ToListAsync();
            }
            return flights;
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDetailsDTO>> GetFlight(int id)
        {
          if (_context.Flights == null)
          {
              return NotFound();
          }
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }
            var passengers = await _context.Passengers.Where(p => p.Tickets.Where(t => t.FlightId == flight.Id).Any()).ToListAsync();
            var fDto = new FlightDetailsDTO
            {
                Id = flight.Id,
                Capacity = flight.Capacity,
                NumPassengers = passengers.Count,
                Departure = flight.Departure,
                Arrival = flight.Arrival,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                FlightNumber = flight.FlightNumber,
                Passengers = passengers
            };
            return Ok(fDto);
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, FlightDTO dto)
        {
            var flight = new Flight(dto, id);
            if (flight.Passengers == null)
            {
                var passengers = await _context.Tickets.Where(t => t.FlightId == flight.Id).ToListAsync();
                flight.Passengers = passengers;
            }
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
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

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(FlightDTO dto)
        {
          if (_context.Flights == null)
          {
              return Problem("Entity set 'FCContext.Flights'  is null.");
          }
            var flight = new Flight(dto);
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return (_context.Flights?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
