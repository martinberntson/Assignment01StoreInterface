using RemakeOneYearLater.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RemakeOneYearLater.Services
{
    public static class DataReader
    {
        public static Task<IEnumerable<Album>> ReadAlbumsAndTracksAsync(string path)
        {
            XmlDocument doc = GetXmlDocumentFromPath(path);
            List<Album> albums = new();
            foreach (XmlNode node in doc.SelectNodes("//Albums/Album"))
            {
                Album album = new Album()
                    {
                        Title = node.Attributes["Title"].Value,
                        TopBillingArtist = node.Attributes["Artist"].Value,
                        ReleaseDate = Convert.ToDateTime(node.Attributes["ReleaseDate"].Value, CultureInfo.InvariantCulture),
                        AverageUserRating = Convert.ToSingle(node.Attributes["AverageUserRating"].Value),
                        Runtime = Convert.ToInt16(node.Attributes["Runtime"].Value),
                        Price = Convert.ToInt16(node.Attributes["Price"].Value)
                    };
                List<Track> tracks = new();
                foreach (XmlNode trackNode in node.ChildNodes)
                {
                    tracks.Add(new Track()
                    {
                        Title = trackNode.Attributes["Title"].Value,
                        Runtime = ConvertTrackRuntime(trackNode.Attributes["Runtime"].Value),
                        FeaturedArtists = trackNode.Attributes["FeatArtist"].Value
                    }) ;
                }
                album.Tracks = tracks;
                albums.Add(album);
            }
            return Task.FromResult<IEnumerable<Album>>(albums);
        }

        private static short ConvertTrackRuntime(string value)
        {
            var array = value.Split(':');
            return (short)(Convert.ToInt32(array[0]) * 60 + Convert.ToInt32(array[1]));
        }

        public static Task<IEnumerable<Movie>> ReadMoviesAsync(string path)
        {
            XmlDocument doc = GetXmlDocumentFromPath(path);
            List<Movie> movies = new();
            foreach (XmlNode node in doc.SelectNodes("//Movies/Movie"))
            {
                movies.Add(new Movie()
                {
                    Title = node.Attributes["Title"].Value,
                    Director = node.Attributes["Director"].Value,
                    ReleaseDate = Convert.ToDateTime(node.Attributes["ReleaseDate"].Value, CultureInfo.InvariantCulture),
                    AverageUserRating = Convert.ToSingle(node.Attributes["AverageUserRating"].Value),
                    Runtime = Convert.ToInt16(node.Attributes["Runtime"].Value),
                    Price = Convert.ToInt16(node.Attributes["Price"].Value)
                });
            }
            return Task.FromResult<IEnumerable<Movie>>(movies);
        }


        private static XmlDocument GetXmlDocumentFromPath(string path)
        {
            Stream stream = File.Open(path, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reader.ReadToEnd());
            return doc;
        }
    }
}
