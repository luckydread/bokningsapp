using System.ComponentModel.DataAnnotations;

namespace bokningsapp.Dtos
{
    public class SlotRequest
    {
        
       // [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }
        
        //[DataType(DataType.Time)]
        public TimeOnly EndTime { get; set; }
    }
}
