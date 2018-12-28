using DentistAppointment.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DentistAppointment.Models
{
    public class PatientFirstLogInViewModel
    {
       
            [Display(Name = "Gender")]
            public string Gender { get; set; }
            [Required]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "The {0} must be at least {2} and must be at max {1} characters long.")]
            [Display(Name = "EGN")]
            public string EGN { get; set; }
            [Required]
            [StringLength(30, MinimumLength = 10, ErrorMessage = "The {0} must be at max {1} characters long.")]
            [Display(Name = "Address")]
            public string Address { get; set; }
      
    }
}
