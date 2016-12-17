using Newtonsoft.Json;

namespace Proxer.Me.Support.Api.Data.List
{
	public class Tag
	{
		#region Public Properties

		public int BlackList { get; set; }

		public string Description { get; set; }

		public int ID { get; set; }

		public string SubType { get; set; }

		[JsonProperty("Tag")]
		public string Name { get; set; }

		public string Type { get; set; }

		#endregion Public Properties
	}
}