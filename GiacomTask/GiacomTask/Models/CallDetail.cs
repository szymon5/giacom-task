using System.ComponentModel.DataAnnotations;

namespace GiacomTask.Models
{
    public class CallDetail
    {
        public int CallDetailID { get; set; }
        public string CallerID { get; set; }
        public string Recipient { get; set; }
        public DateOnly CallDate { get; set; }
        public TimeOnly EndTime {  get; set; }
        public long Duration { get; set; }
        public string Cost { get; set; }
        public string Reference { get; set; }

        [MinLength(3)]
        [MaxLength(3)]
        public string Currency { get; set; }
    }
}
