using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;

namespace DentistAppointment.Models.PatientViewModels
{
    public class PatientMedicalManipulationsHistoryViewModel
    {
        public List<Reservation> IncomingReservations { get; set; }
        public List<Reservation> PastReservations { get; set; }
        public List<Reservation> PastReservationsRate { get; set; }

    }
}