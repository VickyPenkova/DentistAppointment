using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointment.Data.Models
{
    [Table("Events")]
    public class Event : BaseModel<int>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("DentistID")]
        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
