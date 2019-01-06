using DentistAppointment.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.DentistViewModels
{
    public class DentistEditInfoViewModel
    {
        //public User User { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please enter first name longer than than {1}")]
        public string FirstName { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please enter last name longer than than {1}")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public List<SelectListItem> GenderTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Male", Text = "Male"},
            new SelectListItem { Value = "Female", Text = "Female"},
            new SelectListItem { Value = "Other", Text = "Other"},
        };
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please enter last name longer than than {1}")]
        public string Email { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "The {0} must be at least {2} and must be at max {1} characters long.")]
        public string EGN { get; set; }
    }
}
