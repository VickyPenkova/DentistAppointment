using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
            return Db.Include(x => x.User)
                .Where(review => review.Reservation.DentistId == id && review.User.DentistId == null);
        }
    }
}
