using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameBackLog
{
    public class CreateGameDTO
    {
        [Required(ErrorMessage = "Please Enter a Title")]
        [StringLength(150, ErrorMessage = "Characters in Title must be between 1 and 150")]
        public string Title {get; set;}

        [AllowedValues("PC", "Playstation", "Switch", "Xbox", "Mobile", ErrorMessage = "Your Platform must be either: PC, Playstation, Switch, Xbox, or Mobile")]
        public string Platform {get; set;}

        [StringLength(50, ErrorMessage = "Characters in Genre must be between 1 and 50")]
        public string Genre {get; set;}

        [Range(1970, 2100, ErrorMessage = "The Release Year must be between 1970 and 2100")]
        public int ReleaseYear {get; set;}

        [Range(0.0, double.MaxValue)]
        public double HoursPlayed {get; set;}

        [Range(1, 10, ErrorMessage = "The Rating must be between 1 and 10")]
        public int Rating {get; set;}

        [Range(0.0, double.MaxValue)]
        public decimal PricePaid {get; set;}

    }
}