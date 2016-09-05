using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxer.Me.ProxData.Notification.Data
{
	public class NewsData
	{
		public int NID { get; set; }
		public int Time { get; set; }
		public int MID { get; set; }
		public string Description { get; set; }
		[JsonProperty("Image_ID")]
		public string ImageID { get; set; }
		[JsonProperty("Image_Style")]
		public string ImageStyle { get; set; }
		public string Subject { get; set; }
		public int Hits { get; set; }
		public int Thread { get; set; }
		public int UID { get; set; }
		[JsonProperty("UName")]
		public string Username { get; set; }
		public int Posts { get; set; }
		public int CatID { get; set; }
		public string CatName { get; set; }
	}
}
