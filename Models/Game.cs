using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBackLog
{
    public class Game
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Platform {get; set;}
        public string Genre {get; set;}
        public int ReleaseYear {get; set;} 
        public double HoursPlayed {get; set;}
        public int Rating {get; set;}
        public decimal PricePaid {get; set;}
        public string Status {get; set;}
        public DateTime AddedAt {get; set;}
    }
}