using DentistAppointment.Data.Models;
using DentistAppointment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services.Abstraction
{
    public interface IReservationsService
    {
        IEnumerable<DentistWorkHourDTO> GetDentistWorkHoursForDay(int dentistId, DateTime date);
    }
}
