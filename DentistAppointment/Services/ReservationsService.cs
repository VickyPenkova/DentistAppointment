using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.DTOs;
using DentistAppointment.Services.Abstraction;
using DentistAppointment.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DentistAppointment.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly IRepository<Reservation, int> reservationsRepo;
        private readonly IRepository<Dentist, int> dentistRepo;

        public ReservationsService(
            IRepository<Reservation, int> reservationsRepo,
            IRepository<Dentist, int> dentistRepo
            )
        {
            this.reservationsRepo = reservationsRepo;
            this.dentistRepo = dentistRepo;
        }
        
        public IEnumerable<DentistWorkHourDTO> GetDentistWorkHoursForDay(int dentistId, DateTime date)
        {
            Dentist dentist = dentistRepo.GetById(dentistId);
            List<DayOfWeek> workDays = GetDentistWorkDays(dentist);

            List<DentistWorkHourDTO> workHours = new List<DentistWorkHourDTO>();
            
            if (workDays.Contains(date.DayOfWeek))
            {
                for (TimeSpan start = dentist.WorkTimeStart; start < dentist.WorkTimeEnd; start += GlobalConstants.DentistAppointmentLength)
                {
                    workHours.Add(new DentistWorkHourDTO(start, start + GlobalConstants.DentistAppointmentLength, true));
                }
            }
            return workHours;
        }

        private List<DayOfWeek> GetDentistWorkDays(Dentist dentist)
        {
            List<DayOfWeek> workDays = new List<DayOfWeek>();

            string bitmask = new string(Convert.ToString(dentist.WorkDays, 2).Reverse().ToArray());
            for (int i = 0, s = bitmask.Length; i < s; i++)
            {
                if (bitmask[i].Equals('1'))
                {
                    switch (i)
                    {
                        case 0: workDays.Add(DayOfWeek.Sunday); break;
                        case 1: workDays.Add(DayOfWeek.Monday); break;
                        case 2: workDays.Add(DayOfWeek.Tuesday); break;
                        case 3: workDays.Add(DayOfWeek.Wednesday); break;
                        case 4: workDays.Add(DayOfWeek.Thursday); break;
                        case 5: workDays.Add(DayOfWeek.Friday); break;
                        case 6: workDays.Add(DayOfWeek.Saturday); break;
                    }
                }
            }
            return workDays;
        }

    }
}
