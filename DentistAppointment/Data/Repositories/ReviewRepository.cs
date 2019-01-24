using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public virtual IQueryable<Review> GetByUserId(string id)
        {
            return Db.Include(x => x.User.Dentist)
              .Where(review => review.Reservation.UserId == id && review.User.DentistId != null);
        }
    }
}
