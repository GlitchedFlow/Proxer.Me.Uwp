using Newtonsoft.Json;

namespace Proxer.Me.Support.Api.Data.Common
{
	public class UserInfo
	{
		#region Public Properties

		public string Avatar { get; set; }

		[JsonProperty("Points_Anime")]
		public int PointsAnime { get; set; }

		[JsonProperty("Points_Forum")]
		public int PointsForum { get; set; }

		[JsonProperty("Points_Info")]
		public int PointsInfo { get; set; }

		[JsonProperty("Points_Manga")]
		public int PointsManga { get; set; }

		[JsonProperty("Points_Misc")]
		public int PointsMisc { get; set; }

		[JsonProperty("Points_Uploads")]
		public int PointsUploads { get; set; }

		public string Status { get; set; }

		public int UID { get; set; }

		public string Username { get; set; }

		#endregion Public Properties
	}
}