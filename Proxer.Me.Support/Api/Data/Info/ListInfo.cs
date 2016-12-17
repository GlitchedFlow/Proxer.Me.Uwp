using System.Collections.Generic;
using Newtonsoft.Json;
using Proxer.Me.Support.Interfaces;

namespace Proxer.Me.Support.Api.Data.Info
{
	public class Episode : IContentInfo
	{
		#region Public Properties

		[JsonProperty("TypeImg")]
		public string HosterImgs { get; set; }

		[JsonProperty("No")]
		public int Number { get; set; }

		public string Title { get; set; }

		[JsonProperty("Typ")]
		public string Language { get; set; }

		public string Types { get; set; }

		public int ID { get; set; }

		#endregion Public Properties
	}

	public class ListInfo
	{
		#region Public Properties

		[JsonProperty("Kat")]
		public string Category { get; set; }

		public int End { get; set; }

		public List<Episode> Episodes { get; set; }

		[JsonProperty("Lang")]
		public List<string> Languages { get; set; }

		public int Start { get; set; }

		public int State { get; set; }

		#endregion Public Properties
	}
}