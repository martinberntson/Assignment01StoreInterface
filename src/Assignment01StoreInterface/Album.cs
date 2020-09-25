using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment01StoreInterface
{
	class Album : Goods
	{
		public string[] trackTitles { get; }
		public string[] trackRuntimes { get; }
		public string[] trackFeatArtists { get; }
		public short albumTrackCount { get; }

		public Album(List<string> t1, List<string> t2, List<string> t3, string s1, string s2, string s3, decimal d, short sh1, byte b, short sh2) // Konstruktor.
		{
			trackTitles = new string[t1.Count];
			trackRuntimes = new string[t2.Count];
			trackFeatArtists = new string[t3.Count];
			title = s1;
			topBilling = s2;
			releaseDate = s3;
			averageUserRating = d;
			runtime = sh1;
			price = b;
			albumTrackCount = sh2;


			for (int i = 0; i < t1.Count; i++) // Konverterar lista till array.
			{
				trackTitles[i] = t1.ElementAt(i);
			}
			for (int i = 0; i < t2.Count; i++) // Konverterar lista till array.
			{
				trackRuntimes[i] = t2.ElementAt(i);
			}
			for (int i = 0; i < t3.Count; i++) // Konverterar lista till array.
			{
				trackFeatArtists[i] = t3.ElementAt(i);
			}

			runtime = SetAlbumRuntime(trackRuntimes);  // Skickar in array med track runtimes, får tillbaka en summa som skriver över den som hämtats från XML.

		}
		
		

		public string[] AlbumTracks()
        {
			return trackTitles;
        }

		public string AlbumTrack(int i)
        {
			return trackTitles[i];
        }

		public int AlbumTrackCount()
        {
			return trackTitles.Length;
        }

		public string AlbumArtist()					// Här av tydlighetsskäl. Album.AlbumArtist() är tydligare än Album.TopBilling().
        {
			return topBilling;
        }

		public string AlbumRating()
        {
			return Convert.ToString(averageUserRating);
        }

		private short SetAlbumRuntime(string[] sA) // Tar in the array med runtimes i string format.
        {
			int minuteSum = 0;
			int secondSum = 0;
			short sum = 0;
			foreach (string s in sA)
            {
				if (s.Length == 4)  // Kollar om det är fyra tecken [format X:XX]
				{
					minuteSum += Convert.ToInt32(s.Substring(0, 1));
					secondSum += Convert.ToInt32(s.Substring(2, 2));
				}
				else if (s.Length == 5) // Eller fem [format XX:XX]
                {
					minuteSum += Convert.ToInt32(s.Substring(0, 2));
					secondSum += Convert.ToInt32(s.Substring(3, 2));
				}
            }
			sum = (short)(((minuteSum * 60) + secondSum) / 60); // Konverterar minuter till sekunder, lägger ihop allt, 
																// sen konverterar tillbaka till sekunder och kastar sekunder i soporna.
			return sum;
        }
	}
}
