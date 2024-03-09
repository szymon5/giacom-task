using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiacomTask.Models
{
    public class CallDetail
    {
        public int CallDetailID { get; set; }
        public long CallerID { get; set; }
        public string Recipient { get; set; }
        public DateOnly CallDate { get; set; }
        public TimeOnly EndTime {  get; set; }
        public long Duration { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        public string Reference { get; set; }

        [MinLength(3)]
        [MaxLength(3)]
        public string Currency { get; set; }
    }
}
