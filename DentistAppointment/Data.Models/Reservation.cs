using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointment.Data.Models
{
    [Table("Reservations")]
    public class Reservation : BaseModel<int>
    {
        [ForeignKey("DentistID")]
        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }
        [ForeignKey("UserID")]
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string Manipulation { get; set; }
    }
}
