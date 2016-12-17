using Newtonsoft.Json;

namespace Proxer.Me.Support.Api.Data.Notification
{
	public class News
	{
		#region Public Properties

		public int CatID { get; set; }

		public string CatName { get; set; }

		public string Description { get; set; }

		public int Hits { get; set; }

		[JsonProperty("Image_ID")]
		public string ImageID { get; set; }

		[JsonProperty("Image_Style")]
		public string ImageStyle { get; set; }

		public int MID { get; set; }

		public int NID { get; set; }

		public int Posts { get; set; }

		public string Subject { get; set; }

		public int Thread { get; set; }

		public int Time { get; set; }

		public int UID { get; set; }

		[JsonProperty("UName")]
		public string Username { get; set; }

		public string ImageURL
		{
			get { return "http://cdn.proxer.me/news/th/" + NID + "_" + ImageID + ".png"; }
		}

		#endregion Public Properties
	}
}