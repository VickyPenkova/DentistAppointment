using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointment.Data.Models
{
    [Table("Blacklist")]
    public class Blacklist : BaseModel<int>
    {
        [ForeignKey("UserID")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("BlacklistedID")]
        public string BlacklistedId { get; set; }
        public User Blacklisted { get; set; }
    }
}
