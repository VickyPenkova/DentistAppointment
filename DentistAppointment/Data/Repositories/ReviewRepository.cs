using System;
using System.Collections.Generic;
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

        public virtual IEnumerable<Review> GetByDentistId(int id)
        {
            return Db.Where(review => review.Reservation.DentistId == id).ToList();
        }
    }
}
