using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.DTOs
{
    public class DentistWorkHourDTO
    {
        public DentistWorkHourDTO(TimeSpan start, TimeSpan end, DateTime date, bool available, User patient)
        {
            Start = start;
            End = end;
            Date = date;
            Available = available;
            Patient = patient;
        }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public DateTime Date { get; set; }
        public bool Available { get; set; }
        public User Patient { get; set; }
    }
}
