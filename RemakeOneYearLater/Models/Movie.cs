using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemakeOneYearLater.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal AverageUserRating { get; set; }
        public short Runtime { get; set; }
        public short Price { get; set; }


    }
}
