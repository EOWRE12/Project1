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
    public class PassengersController : ControllerBase
    {
        private readonly FCContext _context;
        private readonly ILogger<PassengersController> _logger;

        public PassengersController(ILogger<PassengersController> logger, FCContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Passengers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers()
        {
          if (_context.Passengers == null)
          {
              return NotFound();
          }
            return await _context.Passengers.ToListAsync();
        }

        // GET: api/Passengers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassenger(int id)
        {
          if (_context.Passengers == null)
          {
              return NotFound();
          }
            var passenger = await _context.Passengers.FindAsync(id);
            _logger.LogInformation(passenger.LastName + passenger.FirstName + passenger.Email);
            if (passenger == null)
            {
                return NotFound();
            }
            var flights = await _context.Flights.Where(f => f.Passengers.Where(t => t.PassengerId == passenger.Id).Any()).ToListAsync();
            //var tickets = await _context.Tickets.Where(t => t.PassengerId == passenger.Id).ToListAsync();
            flights.ForEach(f =>
            {
                _logger.LogInformation(f.FlightNumber);
                _logger.LogInformation(f.ArrivalAirport);
                _logger.LogInformation(f.DepartureAirport);
            });
            //_logger.LogError(flights.Count().ToString());
            var pDto = new PassengerDetailsDTO
            {
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                Email = passenger.Email,
                Age = passenger.Age,
                Job = passenger.Job,
                Flights = flights
                //Tickets = tickets 
            };
            return Ok(pDto);
        }

        // PUT: api/Passengers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(int id, PassengerDTO dto)
        {
            var passenger = new Passenger(dto, id);
            if (id != passenger.Id)
            {
                return BadRequest();
            }

            _context.Entry(passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
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

        // POST: api/Passengers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostPassenger(PassengerDTO passengerDto)
        {
          if (_context.Passengers == null)
          {
              return Problem("Entity set 'FCContext.Passengers'  is null.");
          }
            var passenger = new Passenger(passengerDto);
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassenger", new { id = passenger.Id }, passenger);
        }

        // DELETE: api/Passengers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassengerExists(int id)
        {
            return (_context.Passengers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
