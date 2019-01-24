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
        public Dentist Dentist{ get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public String Rating { get; set; }
    }
}
