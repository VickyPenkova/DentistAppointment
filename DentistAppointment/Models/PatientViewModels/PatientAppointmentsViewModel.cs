using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;

namespace DentistAppointment.Models.PatientViewModels
{
    public class PatientAppointmentsViewModel
    {
        public List<Reservation> IncomingReservations { get; set; }
        public List<Reservation> PastReservations { get; set; }
        public int CancelId { get; set; }
    }
}