using Newtonsoft.Json;

namespace Proxer.Me.Support.Api.Data.Info
{
	public class Season
	{
		#region Public Properties

		public int EID { get; set; }

		public int ID { get; set; }

		[JsonProperty("Season")]
		public int SeasonID { get; set; }

		public string Type { get; set; }

		public int Year { get; set; }

		#endregion Public Properties
	}
}