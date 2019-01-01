using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.PatientViewModel
{
    public class PatientEditInfoViewModel
    {
        public User User { get; set; }
        public string FirstName { get; set; }
       
        public string Gender { get; set; }
       
        public string LastName { get; set; }
       
        public string Email { get; set; }
       
        public long EGN { get; set; }

    }
}
