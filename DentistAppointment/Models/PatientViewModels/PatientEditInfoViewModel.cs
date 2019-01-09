using DentistAppointment.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [StringLength(15, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and must be at max {1} characters long.")]
        public string FirstName { get; set; }

        public string Gender { get; set; }

        public List<SelectListItem> GenderTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Male", Text = "Male"},
            new SelectListItem { Value = "Female", Text = "Female"},
            new SelectListItem { Value = "Other", Text = "Other"},
         };
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and must be at max {1} characters long.")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The {0} must be at least {2} and must be at max {1} characters long.")]
        public string EGN { get; set; }

    }
}
