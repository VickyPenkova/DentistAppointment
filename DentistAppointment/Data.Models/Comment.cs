using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointment.Data.Models
{
    [Table("Comments")]
    public class Comment : BaseModel<int>
    {
        [ForeignKey("UserID")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        [ForeignKey("EventID")]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
