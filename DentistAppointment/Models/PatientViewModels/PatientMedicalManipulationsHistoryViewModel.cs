using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;

namespace DentistAppointment.Models.PatientViewModels
{
    public class PatientMedicalManipulationsHistoryViewModel
    {
        public List<Reservation> ReservationsToRate { get; set; }
        public List<Reservation> PastReservations { get; set; }
    }
}