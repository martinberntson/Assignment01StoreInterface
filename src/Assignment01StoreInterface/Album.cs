using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment01StoreInterface
{
	class Album : Goods
	{
		public string[] TrackTitles { get; }
		public string[] TrackRuntimes { get; }
		public string[] TrackFeatArtists { get; }
		public short AlbumTrackCount { get; }

		public Album(List<string> trackTitles, List<string> trackRuntimes, List<string> trackFeatArtists, string title, string topBilling, string releaseDate, decimal averageUserRating, short runtime, byte price, short albumTrackCount) // Konstruktor.
		{
			TrackTitles = new string[trackTitles.Count];
			TrackRuntimes = new string[trackRuntimes.Count];
			TrackFeatArtists = new string[trackFeatArtists.Count];
			Title = title;
			TopBilling = topBilling;
			ReleaseDate = releaseDate;
			AverageUserRating = averageUserRating;
			Runtime = runtime;
			Price = price;
			AlbumTrackCount = albumTrackCount;


			for (int i = 0; i < trackTitles.Count; i++) // Konverterar lista till array.
			{
				TrackTitles[i] = trackTitles.ElementAt(i);
			}
			for (int i = 0; i < trackRuntimes.Count; i++) // Konverterar lista till array.
			{
				TrackRuntimes[i] = trackRuntimes.ElementAt(i);
			}
			for (int i = 0; i < trackFeatArtists.Count; i++) // Konverterar lista till array.
			{
				TrackFeatArtists[i] = trackFeatArtists.ElementAt(i);
			}

			Runtime = GetAlbumRuntime(TrackRuntimes);  // Skickar in array med track runtimes, får tillbaka en summa som skriver över den som hämtats från XML.

		}
		
		

		public string[] GetAlbumTracks()
        {
			return TrackTitles;
        }

		public string GetOneAlbumTrack(int index)
        {
			return TrackTitles[index];
        }

		public int GetAlbumTrackCount()
        {
			return TrackTitles.Length;
        }

		public string GetAlbumArtist()					// Här av tydlighetsskäl. Album.AlbumArtist() är tydligare än Album.TopBilling().
        {
			return TopBilling;
        }

		public string GetAlbumRating()
        {
			return Convert.ToString(AverageUserRating);
        }

		private short GetAlbumRuntime(string[] arrayOfTrackRuntimes) // Tar in the array med runtimes i string format.
        {
			int minuteSum = 0;
			int secondSum = 0;
			short sum;
			foreach (string s in arrayOfTrackRuntimes)
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
