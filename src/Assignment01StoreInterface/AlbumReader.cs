using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Assignment01StoreInterface
{
    class AlbumReader
    {
        // Enter code to read all the album data and then return it here
        public static List<Album> Read(string FilePath)     // FilePath is what it says on the tin - the path to the file that's to be read. 
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
                Console.WriteLine("AlbumData.xml was not found.\r\nPress the any key to continue."); Console.Read();
                // If data isn't found and I manage to create a generator for random data, then use that here instead.
                return null;
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
            
            // Console.WriteLine("Albums read; returning to Main[].");
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

        public static List<Album> Generate(int numberToGenerate)
        {
            List<Album> albumList = new List<Album>();

            for (int i = numberToGenerate; i > 0; i--)
            {
                string s1 = Generator.AlbumTitle();
                string s2 = Generator.Name();
                string s3 = Generator.Date();
                decimal d1 = Generator.Rating();
                byte b2 = Generator.Price();
                List<string> t1 = new List<string>(); // Track Titles
                List<string> t2 = new List<string>(); // Track Runtimes
                List<string> t3 = new List<string>(); // Track Feat. Artist

                

                Random rollTrackCount = new Random();
                int roll = rollTrackCount.Next(1,5);
                bool loop = true;

                int trackCount = 0;
                while (loop)
                {
                    if (roll == 5)
                    {
                        trackCount += roll;
                    }
                    else
                    {
                        trackCount += roll;
                        loop = false;
                    }
                }

                Random featArtistCheck = new Random();
                bool[] featArtistWeight = new bool[]
                {
                    false, false, false, false, true
                };

                for (int n = 0; n < trackCount; n++)
                {
                    t1.Add(Generator.AlbumTitle());
                    t2.Add(Generator.TrackRuntime());
                    bool check = featArtistWeight[(featArtistCheck.Next(1,5) - 1)];
                    if (check)
                    {
                        t3.Add(Generator.Name());
                    }
                    else 
                    { 
                        t3.Add(""); 
                    }
                }
                int runtimeSum = 0; // Sum of track runtimes in seconds
                foreach (string s in t2)
                { 
                    runtimeSum += (Convert.ToInt32(s.Substring(0,1))*60 + Convert.ToInt32(s.Substring(2,2)));
                }
                byte b1 = (byte)(runtimeSum / 60);
                short sh1 = (short)t1.Count;
                
                
                albumList.Add(new Album(t1, t2, t3, s1, s2, s3, d1, b1, b2, sh1));
            }

            return albumList;

        }
    }
}
