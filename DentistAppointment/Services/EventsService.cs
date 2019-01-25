using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services
{
    public class EventsService : IEventsService
    {
        private readonly IRepository<Event, int> eventsRepo;
        private readonly IRepository<Dentist, int> dentistRepo;

        public EventsService(
            IRepository<Event, int> eventsRepo,
            IRepository<Dentist, int> dentistRepo)
        {
            this.eventsRepo = eventsRepo;
            this.dentistRepo = dentistRepo;
        }

        public void AddEvent(Event ev)
        {
            eventsRepo.Add(ev);
            eventsRepo.Save();
        }

        public List<Event> GetDentistAllEvents(int dentistId)
        {
            var events = eventsRepo.GetAll().Where(e => e.DentistId == dentistId).ToList();
            foreach (var ev in events) {
                ev.Dentist = dentistRepo.GetById(dentistId);
            }
            return events;
        }
    }
}
