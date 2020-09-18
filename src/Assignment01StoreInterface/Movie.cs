using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment01StoreInterface
{
    class Movie : Goods
    {

        public Movie(string s1, string s2, string s3, decimal d1, byte b1, byte b2)
        {
            title = s1;
            topBilling = s2;
            releaseDate = s3;
            averageUserRating = d1;
            runtime = (short)b1;
            price = b2;
        }

        public string MovieDirector()  // Tydligare än att ha en TopBilling() metod i Goods
        {
            return topBilling;
        }
    }
}
