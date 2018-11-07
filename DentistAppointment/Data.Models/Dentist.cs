using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointment.Data.Models
{
    [Table("Dentists")]
    public class Dentist : BaseModel<int>
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public TimeSpan WorkTimeStart { get; set; }
        public TimeSpan WorkTimeEnd { get; set; }
        public int WorkDays { get; set; }
        public User User { get; set; }
        public List<Event> Events { get; set; }
    }
}
