using Microsoft.Office.Interop.Excel;
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

			runtime = SetAlbumRuntime(trackRuntimes);

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

		private short SetAlbumRuntime(string[] sA)
        {
			int minuteSum = 0;
			int secondSum = 0;
			short sum = 0;
			foreach (string s in sA)
            {
				if (s.Length == 4)
				{
					minuteSum += Convert.ToInt32(s.Substring(0, 1));
					secondSum += Convert.ToInt32(s.Substring(2, 2));
				}
				else if (s.Length == 5)
                {
					minuteSum += Convert.ToInt32(s.Substring(0, 2));
					secondSum += Convert.ToInt32(s.Substring(3, 2));
				}
            }
			sum = (short)(((minuteSum * 60) + secondSum) / 60);

			return sum;
        }
	}
}
