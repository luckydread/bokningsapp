using System.ComponentModel.DataAnnotations;


namespace bokningsapp.Models
{
    public class Slot
    {
        
        public int SlotId { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }
        public DateTime CreatedAt { get; set; }

        //Navigation property Returns the Booking object that is associated with this slot
      
       
    }
}
