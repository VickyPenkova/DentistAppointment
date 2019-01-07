using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.DTOs
{
    public class DentistWorkHourDTO
    {
        public DentistWorkHourDTO(TimeSpan start, TimeSpan end, bool available)
        {
            Start = start;
            End = end;
            Available = available;
        }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public bool Available { get; set; }
    }
}
