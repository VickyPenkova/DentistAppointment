using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointment.Data.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public string Gender { get; set; }
        public long HealthCard { get; set; }
        public long EGN { get; set; }
        [ForeignKey("DentistID")]
        public int? DentistId { get; set; }
        public Dentist Dentist { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Blacklist> Blacklist { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
