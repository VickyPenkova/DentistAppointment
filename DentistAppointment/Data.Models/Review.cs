using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointment.Data.Models
{
    [Table("Reviews")]
    public class Review : BaseModel<int>
    {
        [ForeignKey("UserID")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("ReservationID")]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public float Rating { get; set; }
    }
}
