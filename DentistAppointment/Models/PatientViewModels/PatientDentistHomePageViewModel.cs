using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.PatientViewModel
{
    public class PatientDentistHomePageViewModel
    {
        public User User { get; set; }
        public string FirstName { get; set; }
       
        public string Gender { get; set; }
       
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }

        public long EGN { get; set; }
        public Dentist Dentist{ get; set; }
        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public double Rating { get; set; }
    }
}
