using System.Globalization;
using bokningsapp.Entities;
using bokningsapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bokningsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private UserManager<User> _userManager;

        public BookingsController(AppDbContext context, UserManager<User> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }

        // GET: api/<BookingsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET api/<BookingsController>/5
        [HttpGet("GetMyBooking")]
        public async Task<ActionResult<Booking>> GetBooking()
        {
            var user = _userManager.Users.FirstOrDefault();
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.UserId == user.Id);
            //var booking = await _context.Bookings.FindAsync(id);
            
            if (booking == null)
            {
                return BadRequest($"You have no booking available.");
            }

           // Console.WriteLine(booking);
            return booking;
        }

        [HttpPost("CreateBooking")]
        public async Task<ActionResult<Booking>> CreateBooking(int slotId, int year, int day, int month)
        {

            //Add validation for date so that it can't be in the past

            DateTime date = new DateTime(year, month, day);

            if (date < DateTime.Today)
            {
                return BadRequest($"You can't make a booking in the past.");
            }
            
            var checkBooking = await _context.Bookings.FirstOrDefaultAsync(b => b.SlotId == slotId && b.Date == date);
            
            if (checkBooking != null)
            {
                return BadRequest($"This slot is already booked on {date}.");
            }

            var user = _userManager.Users.FirstOrDefault();

            var existingBooking = await _context.Bookings.FirstOrDefaultAsync(b => b.UserId == user.Id);

            if (existingBooking != null)
            {
                return BadRequest($"You already have a booking on {existingBooking.Date}. Please cancel it and make a new booking or change the date of that booking to the date you want..");
            }

            var booking = new Booking
            {
                SlotId = slotId,
                Date = date,
                CreatedAt = DateTime.Now,
                UserId = user.Id
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
