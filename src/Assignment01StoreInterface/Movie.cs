using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment01StoreInterface
{
    class Movie
    {
        string movieTitle;
        string movieDirector;
        string movieReleaseDate;
        decimal movieAverageUserRating;
        byte movieRuntime;
        byte moviePrice;

        public Movie(string s1, string s2, string s3, decimal d1, byte b1, byte b2)
        {
            movieTitle = s1;
            movieDirector = s2;
            movieReleaseDate = s3;
            movieAverageUserRating = d1;
            movieRuntime = b1;
            moviePrice = b2;
        }

        public string MovieDate()
        {
            return movieReleaseDate;
        }

        public string MovieTitle()
        {
            return movieTitle;
        }

        public string MovieDirector()
        {
            return movieDirector;
        }
    }
}
