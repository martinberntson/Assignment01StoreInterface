using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assignment01StoreInterface
{
	class Album
	{
		private string[] trackTitles;
		private string[] trackRuntimes;
		private string[] trackFeatArtists;
		private string albumTitle;
		private string albumArtist;
		private string albumDate;
		private decimal albumAverageUserRating;
		private short albumRuntime;
		private byte albumPrice;
		private short albumTrackCount;

		public Album(List<string> t1, List<string> t2, List<string> t3, string s1, string s2, string s3, decimal d, short sh1, byte b, short sh2) 
		{
			trackTitles = new string[t1.Count];
			trackRuntimes = new string[t2.Count];
			trackFeatArtists = new string[t3.Count];
			albumTitle = s1;
			albumArtist = s2;
			albumDate = s3;
			albumAverageUserRating = d;
			albumRuntime = sh1;
			albumPrice = b;
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
		public string AlbumDate()
		{
			return albumDate;
		}
		public string AlbumTitle()
		{
			return albumTitle;
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

		public string AlbumArtist()
        {
			return albumArtist;
        }
	}
}
