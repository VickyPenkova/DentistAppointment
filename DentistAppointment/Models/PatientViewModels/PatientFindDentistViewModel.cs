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
    public class PatientFindDentistViewModel
    {
        public string City { get; set; }
        public List<SelectListItem> NameOfCity { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Sofia", Text = "Sofia"},
            new SelectListItem { Value = "Plovdiv", Text = "Plovdiv"},
            new SelectListItem { Value = "Varna", Text = "Varna"},
            new SelectListItem { Value = "Burgas", Text = "Burgas"},
            new SelectListItem { Value = "Veliko Tarnovo", Text = "Veliko Tarnovo"},
        };
        public string Type { get; set; }
        public List<SelectListItem> DentistTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Endodont", Text = "Endodont"},
            new SelectListItem { Value = "Orthodontist", Text = "Orthodontist"},
            new SelectListItem { Value = "Pediatric dentist", Text = "Pediatric dentist"},
            new SelectListItem { Value = "Surgeon", Text = "Surgeon"},
            new SelectListItem { Value = "Periodontist", Text = "Periodontist"},
        };
        public string LastName { get; set; }
        public double Rating { get; set; }
        public List<SelectListItem> NumberOfStars { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "None"},
            new SelectListItem { Value = "1", Text = "Above one star"},
            new SelectListItem { Value = "2", Text = "Above two stars"},
            new SelectListItem { Value = "3", Text = "Above tree stars"},
            new SelectListItem { Value = "4", Text = "Above four stars"},
        };
        public List<Dentist> Dentists { get; internal set; }
    }
}
