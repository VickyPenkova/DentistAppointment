using DentistAppointment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.PatientViewModels
{
    public class PatientBookingModel
    {
        public List<DentistWorkHourDTO> WorkHours { get; set; }
        public DateTime Start { get; set; }
        public DateTime Date { get; set; }
        public DateTime Now { get; set; }
    }
}
