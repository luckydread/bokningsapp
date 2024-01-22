using System.ComponentModel.DataAnnotations;
using bokningsapp.Entities;

namespace bokningsapp.Models
{
    public class Booking
    {
        
        public int BookingId { get; set; }
        public int SlotId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
       
      
    }
}
