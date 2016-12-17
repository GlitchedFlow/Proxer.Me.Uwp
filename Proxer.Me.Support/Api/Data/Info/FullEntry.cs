using System.Collections.Generic;
using Newtonsoft.Json;
using Proxer.Me.Support.Enums.Data;
using Proxer.Me.Support.Interfaces;

namespace Proxer.Me.Support.Api.Data.Info
{
	public class FullEntry : IRateable
	{
		#region Public Properties

		[JsonProperty("Kat")]
		public string Category { get; set; }

		public int Clicks { get; set; }

		public int Count { get; set; }

		public string Description { get; set; }

		public string FSK { get; set; }

		public bool Gate { get; set; }

		public string Genre { get; set; }

		public List<Group> Groups { get; set; }

		public int ID { get; set; }

		[JsonProperty("Lang")]
		public List<string> Languages { get; set; }

		public int License { get; set; }

		public Medium Medium { get; set; }

		public string Name { get; set; }

		public List<EntryName> Names { get; set; }

		public List<Publisher> Publisher { get; set; }

		[JsonProperty("Rate_Count")]
		public int RateCount { get; set; }

		[JsonProperty("Rate_Sum")]
		public int RateSum { get; set; }

		public List<Season> Seasons { get; set; }

		public int State { get; set; }

		public List<Tag> Tags { get; set; }

		public List<Group> People
		{
			get
			{
				List<Group> result = new List<Group>();
				result.AddRange(Groups);
				result.AddRange(Publisher);
				return result;
			}
		}

		#endregion Public Properties
	}
}