﻿using System.Linq;

namespace DentistAppointment.Data.Models
{
    public class ReviewRepository : GenericRepository<Review, int>
    {
        public ReviewRepository(DentistAppointmentDbContext context) :
            base(context)
        {
        }

        public virtual IQueryable<Review> GetByDentistId(int id)
        {
            return Db.Where(review => review.Reservation.DentistId == id && review.User.DentistId == null);
        }
    }
}
