using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models
{
    public class PatientHomePageViewModel
    {
        public string FirstName { get; set; }
       
        public string Gender { get; set; }
       
        public string LastName { get; set; }
       
        public string Email { get; set; }
       
        public string EGN { get; set; }
        
        public string Address { get; set; }
    }
}
