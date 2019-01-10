using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string Gender { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long EGN { get; set; }

        public string Address { get; set; }
        public IEnumerable<UserDTO> User { get; set; }
        public Guid Id { get; internal set; }
    }
}
