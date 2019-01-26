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

        [StringLength(60, MinimumLength = 10, ErrorMessage = "The {0} must be at least {2} and must be at max {1} characters long.")]
        public string EGN { get; set; }

        public IEnumerable<SelectListItem> WorkDays { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Sunday"},
            new SelectListItem { Value = "2", Text = "Monday"},
            new SelectListItem { Value = "4", Text = "Tuesday"},
            new SelectListItem { Value = "8", Text = "Wednesday"},
            new SelectListItem { Value = "16", Text = "Thursday"},
            new SelectListItem { Value = "32", Text = "Friday"},
            new SelectListItem { Value = "64", Text = "Saturday"},
        };


        public int[] SelectedWorkDays { get; set; }
        // 1 : Sunday
        // 2 : Monday
        // 4 : Tuesday
        // 8 : Wednesday
        //16 : Thursday
        //32 : Friday
        //64 : Saturday
    }
}
