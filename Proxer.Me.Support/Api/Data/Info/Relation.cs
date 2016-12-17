using Newtonsoft.Json;
using Proxer.Me.Support.Enums.Data;
using Proxer.Me.Support.Interfaces;

namespace Proxer.Me.Support.Api.Data.Info
{
	public class Relation : IRateable
	{
		#region Public Properties

		[JsonProperty("Kat")]
		public string Category { get; set; }

		public int Clicks { get; set; }

		public int Count { get; set; }

		public string Description { get; set; }

		public string FSK { get; set; }

		public string Genre { get; set; }

		public int ID { get; set; }

		public string Language { get; set; }

		public int License { get; set; }

		public Medium Medium { get; set; }

		public string Name { get; set; }

		[JsonProperty("Rate_Count")]
		public int RateCount { get; set; }

		[JsonProperty("Rate_Sum")]
		public int RateSum { get; set; }

		public int? Season { get; set; }

		public int State { get; set; }

		public int? Year { get; set; }

		#endregion Public Properties
	}
}