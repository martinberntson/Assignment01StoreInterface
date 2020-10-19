

namespace Assignment01StoreInterface
{
    class Goods								// topBilling har ingen getter, då det är mer tydligt med Movie.GetDirector och Album.GetArtist än X.GetTopBilling
    {
		public string Title;
		public string TopBilling;
		public string ReleaseDate;
		public decimal AverageUserRating;
		public short Runtime;
		public byte Price;

		public string GetTitle()
		{
			return Title;
		}
		public string Date()
		{
			return ReleaseDate;
		}
	}
}
