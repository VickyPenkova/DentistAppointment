using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentistAppointment.Models.DentistViewModels
{
    public class DentistFindAPatientViewModel
    {
        public long EGN { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public IEnumerable<User> Patients { get; set; }
    }
}
