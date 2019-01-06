using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DentistAppointment.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IRepository<User, string> usersRepo;
        private readonly ReviewRepository reviewsRepo;
        private readonly IRepository<Reservation, int> reservationsRepo;

        public ReviewsService(
            IRepository<User, string> usersRepo,
            ReviewRepository reviewsRepo,
             IRepository<Reservation, int> reservationsRepo)
        {
            this.usersRepo = usersRepo;
            this.reviewsRepo = reviewsRepo;

            this.reservationsRepo = reservationsRepo;
        }

        public IEnumerable<Review> GetAllByUser(int dentistId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetAllByDentist(int dentistId)
        {
            var reservations = this.reservationsRepo
                .GetAll()
                .Where(x => x.DentistId == dentistId).ToList();
            var users = new List<User>();
            foreach(Reservation r in reservations)
            {
                users.AddRange(usersRepo.GetAll().Where(u => u.Id == r.UserId));
            }

            var reviewsForDentist = new List<Review>();

            foreach (var r in reservations)
            {
                reviewsForDentist.AddRange(reviewsRepo
                .GetAll()
                .Include(x => x.User)
               .Where(c => c.ReservationId == r.Id).ToList());
            }

            //return reviewsForDentist;
            return this.reviewsRepo.GetByDentistId(dentistId);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public string GetContentOfReview(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
