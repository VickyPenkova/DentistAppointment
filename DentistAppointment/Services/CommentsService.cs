using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Dentist, int> dentistsRepo;
        private readonly IRepository<User, string> usersRepo;
        private readonly IRepository<Comment, int> commentsRepo;
        private readonly IRepository<Event, int> eventsRepo;

        public CommentsService(
            IRepository<Dentist, int> dentistsRepo,
            IRepository<User, string> usersRepo,
            IRepository<Comment, int> commentsRepo,
            IRepository<Event, int> eventsRepo)
        {
            this.dentistsRepo = dentistsRepo;
            this.usersRepo = usersRepo;
            this.commentsRepo = commentsRepo;
            this.eventsRepo = eventsRepo;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return commentsRepo.GetAll();
        }

        public IEnumerable<Comment> GetAllCommentsOfDentist(int dentistId)
        {
            var events = this.eventsRepo
                .GetAll()
                .Where(x => x.DentistId == dentistId).ToList();
            var commentsForDentist = new List<Comment>();
            foreach(var e in events){
                commentsForDentist.AddRange(commentsRepo
                .GetAll()
               .Where(c => c.EventId == e.Id).ToList());
            }
            return commentsForDentist;
        }

        public string GetContentOfComment(int commentId)
        {
            return commentsRepo.GetById(commentId).Content;
        }
    }
}
