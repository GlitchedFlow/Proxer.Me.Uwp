using Newtonsoft.Json;
using Proxer.Me.Support.Enums.Data;
using Proxer.Me.Support.Interfaces;

namespace Proxer.Me.Support.Api.Data.List
{
	public class EntryList : IRateable
	{
		#region Public Properties

		public int Count { get; set; }

		public string Genre { get; set; }

		public int ID { get; set; }

		public string Language { get; set; }

		public Medium Medium { get; set; }

		public string Name { get; set; }

		[JsonProperty("Rate_Count")]
		public int RateCount { get; set; }

		[JsonProperty("Rate_Sum")]
		public int RateSum { get; set; }

		public int State { get; set; }

		#endregion Public Properties
	}
}