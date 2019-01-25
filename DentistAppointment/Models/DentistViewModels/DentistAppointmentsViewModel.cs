using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.DentistViewModels
{
    public class DentistAppointmentsViewModel
    {
        public List<Reservation> IncomingReservations { get; set; }
        public List<Reservation> PastReservations { get; set; }
    }
}
