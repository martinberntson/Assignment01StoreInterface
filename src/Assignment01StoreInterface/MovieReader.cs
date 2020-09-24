using System;
using System.Collections.Generic;
using System.Xml;

namespace Assignment01StoreInterface
{
    class MovieReader
    {
        // Enter code to read and then return all the movie data here
        public static List<Movie> Read(string FilePath)
        {
            List<Movie> movies = new List<Movie>();


            XmlDocument xDoc = new XmlDocument();
            try { xDoc.Load(FilePath); }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("MovieData.xml was not found.\r\nGenerating new data...\r\nPress the any key (enter) to continue."); Console.Read();
                // If data isn't found and I manage to create a generator for random data, then use that here instead.
                return MovieReader.Generate(25);
            }
            XmlNodeList itemNodes = xDoc.SelectNodes("//Movies/Movie");
            // Console.WriteLine(itemNodes.Count);

            foreach (XmlNode movieNode in itemNodes)
            {
                movies.Add(new Movie(movieNode.Attributes["Title"].Value, movieNode.Attributes["Director"].Value, movieNode.Attributes["ReleaseDate"].Value, Convert.ToDecimal(movieNode.Attributes["AverageUserRating"].Value), Convert.ToByte(movieNode.Attributes["Runtime"].Value), Convert.ToByte(movieNode.Attributes["Price"].Value)));
                // Console.WriteLine($"{movieNode.Attributes["Title"].Value} \r\n  {movieNode.Attributes["Director"].Value} \r\n  {movieNode.Attributes["ReleaseDate"].Value} \r\n  {movieNode.Attributes["AverageUserRating"].Value} \r\n  {movieNode.Attributes["ReleaseDate"].Value} \r\n  {movieNode.Attributes["Runtime"].Value} \r\n  {movieNode.Attributes["Price"].Value}");
                // Console.WriteLine($"Movie {movieNode.Attributes["Title"].Value} added to list.");
            }
            return movies;
        }

        public static List<Movie> Generate(int numberToGenerate)
        {
            List<Movie> movieList = new List<Movie>();

            for (int i = numberToGenerate; i> 0; i--)
            {
                string s1 = Generator.MovieTitle();
                string s2 = Generator.Name();
                string s3 = Generator.Date();
                decimal d1 = Generator.Rating();
                byte b1 = Generator.MovieRuntime();
                byte b2 = Generator.Price();
                movieList.Add(new Movie(s1, s2, s3, d1, b1, b2));
            }

            return movieList;

        }
    }
}
