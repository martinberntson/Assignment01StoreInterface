using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Assignment01StoreInterface
{
    class AlbumReader
    {
        // Enter code to read all the album data and then return it here
        public static List<Album> Read(string FilePath)
        {
            List<Album> albums = new List<Album>();
            List<string> trackTitles;
            List<string> trackRuntimes;
            List<string> trackFeatArtists;
            string albumTitle;
            string albumArtist;
            string albumDate;
            decimal albumAverageUserRating;
            short albumRuntime;
            byte albumPrice;
            short albumTrackCount;

            XmlDocument xDoc = new XmlDocument();

            try { xDoc.Load(FilePath); }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("AlbumData.xml was not found.");
                // If data isn't found and I manage to create a generator for random data, then use that here instead.
            }
            XmlNodeList itemNodes = xDoc.SelectNodes("//Albums/Album");
            // Console.WriteLine(itemNodes.Count);

            foreach (XmlNode albumNode in itemNodes)
            {
                albumTitle = albumNode.Attributes["Title"].Value;
                albumArtist = albumNode.Attributes["Artist"].Value;
                albumDate = albumNode.Attributes["ReleaseDate"].Value;
                albumAverageUserRating = Convert.ToDecimal(albumNode.Attributes["AverageUserRating"].Value);
                albumRuntime = (short)Convert.ToInt32(albumNode.Attributes["Runtime"].Value);
                albumPrice = Convert.ToByte(albumNode.Attributes["Price"].Value);
                albumTrackCount = (short)Convert.ToInt32(albumNode.Attributes["Tracks"].Value);

                
                trackTitles = new List<string>();
                trackRuntimes = new List<string>();
                trackFeatArtists = new List<string>();

                foreach (XmlNode trackNode in albumNode.ChildNodes)
                {
                    if (trackNode.Attributes.Count == 3)
                    {
                        trackTitles.Add(trackNode.Attributes["Title"].Value);
                        trackRuntimes.Add(trackNode.Attributes["Runtime"].Value);
                        trackFeatArtists.Add(trackNode.Attributes["FeatArtist"].Value);
                    }
                    else { }
                }
                Album newAlbum = new Album(trackTitles, trackRuntimes, trackFeatArtists, albumTitle, albumArtist, albumDate, albumAverageUserRating, albumRuntime, albumPrice, albumTrackCount);
      
                albums.Add(newAlbum);

                // Console.WriteLine($"Album {albumNode.Attributes["Title"].Value} added to list.");
            }
            
            Console.WriteLine("Albums read; returning to Main[].");
            return albums;


            /* foreach(XmlNode albumNode in itemNodes)
            {
                Console.WriteLine($"{albumNode.Attributes["Title"].Value}, {albumNode.Attributes["Artist"].Value}, {albumNode.Attributes["ReleaseDate"].Value}, {albumNode.Attributes["AverageUserRating"].Value}, {albumNode.Attributes["Runtime"].Value} {albumNode.Attributes["Price"].Value}, {albumNode.Attributes["Tracks"].Value}  ");
                
                foreach (XmlNode trackNode in albumNode.ChildNodes)
                {
                    if (trackNode.Attributes.Count == 3)
                        if (trackNode.Attributes["FeatArtist"].Value == "")
                        {
                            Console.WriteLine($"  {trackNode.Attributes["Title"].Value} \r\n    {trackNode.Attributes["Runtime"].Value}");
                        }
                        else 
                        {
                            Console.WriteLine($"  {trackNode.Attributes["Title"].Value} \r\n    {trackNode.Attributes["Runtime"].Value} \r\n    {trackNode.Attributes["FeatArtist"].Value} ");
                        }
                    else { }
                }
            }*/

        }
    }
}
