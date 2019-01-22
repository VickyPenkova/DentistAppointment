using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.AdminViewModels
{
    public class AddDentistViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please enter first name longer than than {1}")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please enter last name longer than than {1}")]
        public string LastName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Please enter user name longer than than {1}")]
        public string EmailAndUserName { get; set; }

        [Required]
        [StringLength(maximumLength: 14, MinimumLength = 10, ErrorMessage = "The {0} must be at least {2} and must be at max {1} characters long.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Please enter password longer than than {1}")]
        public string Password { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Please enter city longer than than {1}")]
        public string City { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Please enter address longer than than {1}")]
        public string Address { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Please enter type longer than than {1}")]
        public string Type { get; set; }

    }
}
