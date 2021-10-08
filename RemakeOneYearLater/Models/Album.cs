using System;
using System.Collections.Generic;

namespace RemakeOneYearLater.Models
{
    class Album
    {
        public string Title { get; set; }
        public string TopBillingArtist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal AverageUserRating { get; set; }
        public short Runtime { get; set; }
        public short Price { get; set; }
        public List<Track> Tracks { get; set; }

    }
}
