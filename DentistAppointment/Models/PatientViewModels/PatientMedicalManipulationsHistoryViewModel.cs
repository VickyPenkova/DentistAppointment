using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;

namespace DentistAppointment.Models.PatientViewModels
{
    public class PatientMedicalManipulationsHistoryViewModel
    {
        public List<Reservation> Reservations { get; set; }
    }
}