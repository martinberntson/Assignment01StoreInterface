

namespace Assignment01StoreInterface
{
    class Goods								// topBilling har ingen getter, då det är mer tydligt med Movie.GetDirector och Album.GetArtist än X.GetTopBilling
    {
		public string title;
		public string topBilling;
		public string releaseDate;
		public decimal averageUserRating;
		public short runtime;
		public byte price;

		public string Title()
		{
			return title;
		}
		public string Date()
		{
			return releaseDate;
		}
	}
}
