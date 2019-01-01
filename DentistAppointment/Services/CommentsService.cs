using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Dentist, int> dentistsRepo;
        private readonly IRepository<User, string> usersRepo;
        private readonly IRepository<Comment, int> commentsRepo;

        public CommentsService(
            IRepository<Dentist, int> dentistsRepo,
            IRepository<User, string> usersRepo,
            IRepository<Comment, int> commentsRepo)
        {
            this.dentistsRepo = dentistsRepo;
            this.usersRepo = usersRepo;
            this.commentsRepo = commentsRepo;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return commentsRepo.GetAll();
        }

        public IEnumerable<Comment> GetAllCommentsOfDentist(int dentistId)
        {
            return commentsRepo
                .GetAll()
                .Where(comments => comments.User.DentistId == dentistId);
        }
      /*  //Comments for patient
        public IEnumerable<Comment> GetAllCommentsOfPatient(int userId)
        {
            return commentsRepo
                .GetAll()
                .Where(comments => comments.User.UserId == userId);
        }*/
        public string GetContentOfComment(int commentId)
        {
            return commentsRepo.GetById(commentId).Content;
        }
    }
}
