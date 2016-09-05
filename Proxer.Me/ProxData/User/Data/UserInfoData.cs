using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxer.Me.ProxData.User.Data
{
	public class UserInfoData
	{
		public int UID { get; set; }
		public string Username { get; set; }
		public string Avatar { get; set; }
		public string Status { get; set; }
		[JsonProperty("Points_Uploads")]
		public int PointsUploads { get; set; }
		[JsonProperty("Points_Anime")]
		public int PointsAnime { get; set; }
		[JsonProperty("Points_Manga")]
		public int PointsManga { get; set; }
		[JsonProperty("Points_Info")]
		public int PointsInfo { get; set; }
		[JsonProperty("Points_Forum")]
		public int PointsForum { get; set; }
		[JsonProperty("Points_Misc")]
		public int PointsMisc { get; set; }
	}
}
