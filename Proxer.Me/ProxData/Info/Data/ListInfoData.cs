using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxer.Me.ProxData.Info.Data
{
	public class ListInfoData
	{
		public int Start { get; set; }
		public int End { get; set; }
		[JsonProperty("Kat")]
		public string Category { get; set; }
		[JsonProperty("Lang")]
		public List<string> Languages { get; set; }
		public int State { get; set; }
		public List<EpisodeData> Episodes { get; set; }
	}

	public class EpisodeData
	{
		[JsonProperty("No")]
		public int Number { get; set; }
		public string Title { get; set; }
		[JsonProperty("Typ")]
		public string Type { get; set; }
		public string Types { get; set; }
		[JsonProperty("TypeImg")]
		public string HosterImgs { get; set; }

	}
}
