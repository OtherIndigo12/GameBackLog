using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBackLog
{
    public class UpdateStatusDTO
    {
        [Required(ErrorMessage = "Please Enter a Status for the game.")]
        [AllowedValues("Backlog", "Playing", "Completed", "Dropped", ErrorMessage = "Your Status must be either: Backlog, Playing, Completed, or Dropped")]
        public string Status {get; set;}
    }
}