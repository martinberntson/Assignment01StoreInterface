

namespace Assignment01StoreInterface
{
    class Goods
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
