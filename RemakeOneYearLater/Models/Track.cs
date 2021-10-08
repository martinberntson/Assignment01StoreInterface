using System.Collections.Generic;

namespace RemakeOneYearLater.Models
{
    public class Track
    {
        public string Title { get; set; }
        public short Runtime { get; set; }
        public IEnumerable<string> FeaturedArtists { get; set; }
    }
}