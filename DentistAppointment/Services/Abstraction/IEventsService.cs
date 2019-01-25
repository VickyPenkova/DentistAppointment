using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services.Abstraction
{
    public interface IEventsService
    {
        void AddEvent(Event ev);
        List<Event> GetDentistAllEvents(int dentistId);
    }
}
