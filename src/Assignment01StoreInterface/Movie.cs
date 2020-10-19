namespace Assignment01StoreInterface
{
    class Movie : Goods
    {

        public Movie(string title, string topBilling, string releaseDate, decimal averageUserRating, byte runtime, byte price)
        {
            Title = title;
            TopBilling = topBilling;
            ReleaseDate = releaseDate;
            AverageUserRating = averageUserRating;
            Runtime = (short)runtime;
            Price = price;
        }

        public string GetMovieDirector()                       // Endast här istället för i Goods.cs för att det är tydligare att ha Movie.MovieDirector() än Movie.TopBilling()
        {                                                   // Speciellt då TopBilling är mer troligt att referera till skådespelare. 
            return TopBilling;
        }
    }
}
