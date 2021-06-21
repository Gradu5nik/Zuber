using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.Models
{
    public class Invite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Ride")]
        public int RideID { get; set; }
        [ForeignKey("ZuberUser")]
        public int ZuberUserID { get; set; }

        [Required]
        public Ride Ride { get; set; }
        public ZuberUser ZuberUser { get; set; }
    }
}
