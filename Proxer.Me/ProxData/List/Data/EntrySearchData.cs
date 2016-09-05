using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.List.Data
{
	public class EntrySearchData
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Genre { get; set; }
		public Medium Medium { get; set; }
		public int Count { get; set; }
		public int State { get; set; }
		[JsonProperty("Rate_Sum")]
		public int RateSum { get; set; }
		[JsonProperty("Rate_Count")]
		public int RateCount { get; set; }
		public string Language { get; set; }
	}
}
