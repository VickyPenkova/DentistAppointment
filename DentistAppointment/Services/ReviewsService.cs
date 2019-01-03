using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Services.Abstraction;
using System;
using System.Collections.Generic;

namespace DentistAppointment.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IRepository<User, string> usersRepo;

        public ReviewsService(
            IRepository<User, string> usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        public IEnumerable<Review> GetAllByUser(int dentistId)
        {
            throw new NotImplementedException();
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
