using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BowlerFun.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerId { get; set; }
        public string BowlerLastName { get; set; }

        [Required(ErrorMessage ="We need a name!")]
        public string BowlerFirstName { get; set; }

        [MaxLength(1)]
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }

        [MaxLength(2)]
        public string BowlerState { get; set; }
        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }


    }
}
