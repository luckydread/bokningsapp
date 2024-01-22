using System.Globalization;
using bokningsapp.Entities;
using bokningsapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bokningsapp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ElevatedRights")]
    [ApiController]
    public class SlotsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public SlotsController(AppDbContext context)
        {
                _context = context;
        }

        // GET: api/<SlotsController>
       [HttpGet]
        public async Task <ActionResult<IEnumerable<Slot>>> GetAllSlots()
        {
            return await _context.Slots.ToListAsync();
        }

        // GET api/<SlotsController>/5
        [HttpGet("GetSlot/{id}")]
        public async Task<ActionResult<Slot>> GetSlot(int id)
        {
            //Try lambda expression
            //var slot = _context.Slots.FirstOrDefault(s => s.SlotId == id);
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null)
            {
                return BadRequest($"There is no slot with the id {id} available.");
            }
            return slot;
        }

        // POST api/<SlotsController>
        [HttpPost("CreateSlot")]
        public async Task<ActionResult<Slot>>  CreateSlot(string start, string end)
        {
                       
             var NewSlot = new Slot 
             {
                 StartTime =   TimeOnly.Parse(start, CultureInfo.InvariantCulture),
                 EndTime   =   TimeOnly.Parse(end, CultureInfo.InvariantCulture),
                 CreatedAt =   DateTime.Now
             };
             
            _context.Slots.Add(NewSlot);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSlot), new { id = NewSlot.SlotId }, NewSlot);
        }

        // DELETE api/<SlotsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Slot>>  DeleteSlot(int id)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null)
            {
                return BadRequest($"There is no slot with the id {id} available.");
            }
            _context.Slots.Remove(slot);
            _context.SaveChanges();
            return Ok($"The slot with the id {id} was deleted.");
        }
    }
}
