using Newtonsoft.Json;
using Proxer.Me.Support.Enums.Data;
using Proxer.Me.Support.Interfaces;

namespace Proxer.Me.Support.Api.Data.UCP
{
	public class Reminder : IContentInfo
	{
		#region Public Properties

		[JsonProperty("Kat")]
		public string Category { get; set; }

		public int EID { get; set; }

		[JsonProperty("Episode")]
		public int Number { get; set; }

		public int ID { get; set; }

		public string Language { get; set; }

		public Medium Medium { get; set; }

		public string Name { get; set; }

		public int State { get; set; }

		#endregion Public Properties
	}
}