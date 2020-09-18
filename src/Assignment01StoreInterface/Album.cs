using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assignment01StoreInterface
{
	class Album : Goods
	{
		private string[] trackTitles;
		private string[] trackRuntimes;
		private string[] trackFeatArtists;
		private short albumTrackCount;

		public Album(List<string> t1, List<string> t2, List<string> t3, string s1, string s2, string s3, decimal d, short sh1, byte b, short sh2) 
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


			for (int i = 0; i < t1.Count; i++)
			{
				trackTitles[i] = t1.ElementAt(i);
			}
			for (int i = 0; i < t2.Count; i++)
			{
				trackRuntimes[i] = t2.ElementAt(i);
			}
			for (int i = 0; i < t3.Count; i++)
			{
				trackFeatArtists[i] = t3.ElementAt(i);
			}

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

		public string AlbumArtist() // This is here instead of in Goods because its name is more clear on what data is get fetched.
        {
			return topBilling;
        }

		public string AlbumRating()
        {
			return Convert.ToString(averageUserRating);
        }
	}
}
