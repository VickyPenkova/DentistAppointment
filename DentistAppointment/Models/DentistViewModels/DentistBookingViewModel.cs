using DentistAppointment.Data.Models;
using DentistAppointment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.DentistViewModels
{
    public class DentistBookingViewModel
    {
        public List<DentistWorkHourDTO> WorkHours { get; set; }
        public int CancelId { get; set; }
        public List<Event> Events { get; set; }
    }
}
