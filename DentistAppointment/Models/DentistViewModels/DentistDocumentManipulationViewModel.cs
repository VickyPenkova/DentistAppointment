using DentistAppointment.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.DentistViewModels
{
    public class DentistDocumentManipulationViewModel
    {
        [Required]
        public Reservation Reservation { get; set; }

        public string Punctuality { get; set; }

        [Required]
        public List<SelectListItem> punctualityList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value= "1", Text = "Very dissatisfied"},
            new SelectListItem { Value = "2", Text = "Dissatisfied"},
            new SelectListItem { Value = "3", Text = "Okay"},
            new SelectListItem { Value = "4", Text = "Satisfied"},
            new SelectListItem { Value = "5", Text = "Very Satisfied"},
        };

        public string Examination { get; set; }

        [Required]
        public List<SelectListItem> examinationList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Very dissatisfied"},
            new SelectListItem { Value = "2", Text = "Dissatisfied"},
            new SelectListItem { Value = "3", Text = "Okay"},
            new SelectListItem { Value = "4", Text = "Satisfied"},
            new SelectListItem { Value = "5", Text = "Very Satisfied"},
        };

        public double Rating { get; set; }
    }
}
