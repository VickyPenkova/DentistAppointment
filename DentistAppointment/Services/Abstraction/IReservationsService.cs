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
        List<DentistWorkHourDTO> GetDentistWorkHoursForDay(int dentistId, DateTime date);
        void MakeReservation(string userId, int dentistId, DateTime date);
        IEnumerable<Reservation> GetAllReservationsOfDentist(int dentistId);
        IEnumerable<Reservation> GetAllReservationsOfUser(string userId, int dentistId);
        Reservation GetReservationById(int reservationId);
    }
}
