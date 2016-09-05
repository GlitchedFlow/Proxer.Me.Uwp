using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.Info.Data
{
	public class RelationData
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Genre { get; set; }
		public string FSK { get; set; }
		public string Description { get; set; }
		public Medium Medium { get; set; }
		public int Count { get; set; }
		public int State { get; set; }
		[JsonProperty("Rate_Sum")]
		public int RateSum { get; set; }
		[JsonProperty("Rate_Count")]
		public int RateCount { get; set; }
		public int Clicks { get; set; }
		[JsonProperty("Kat")]
		public string Category { get; set; }
		public int License { get; set; }
		public string Language { get; set; }
		public int? Year { get; set; }
		public int? Season { get; set; }
	}
}
