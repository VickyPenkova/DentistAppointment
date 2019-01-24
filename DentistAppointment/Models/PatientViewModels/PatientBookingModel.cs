using DentistAppointment.Data.Models;
using DentistAppointment.DTOs;
using System;
using System.Collections.Generic;

namespace DentistAppointment.Models.PatientViewModels
{
    public class PatientBookingModel
    {
        public List<DentistWorkHourDTO> WorkHours { get; set; }
        public DateTime Start { get; set; }
        public DateTime Date { get; set; }
    }
}
