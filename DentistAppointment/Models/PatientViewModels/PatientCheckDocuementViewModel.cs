using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.PatientViewModels
{
    public class PatientCheckDocumentViewModel
    {
        public Reservation Reservation { get; set; }
        public Review Review { get; set; }
    }
}