using DentistAppointment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.PatientViewModel
{
    public class PatientBookingModel
    {
        public IEnumerable<DentistWorkHourDTO> WorkHours { get; set; }
    }
}
