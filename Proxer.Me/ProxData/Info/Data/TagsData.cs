using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxer.Me.ProxData.Info.Data
{
	public class TagsData
	{
		public int ID { get; set; }
		public int TID { get; set; }
		public DateTime TimeStamp { get; set; }
		[JsonProperty("Rate_Flag")]
		public int RateFlag { get; set; }
		[JsonProperty("Spoiler_Flag")]
		public int SpoilerFlag { get; set; }
		public string Tag { get; set; }
		public string Description { get; set; }
	}
}
