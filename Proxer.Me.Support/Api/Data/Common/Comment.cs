using Newtonsoft.Json;
using Proxer.Me.Support.Enums.Data;

namespace Proxer.Me.Support.Api.Data.Common
{
	public class Comment
	{
		#region Public Properties

		public string Avatar { get; set; }

		[JsonProperty("Comment")]
		public string Content { get; set; }

		public string Data { get; set; }

		public int Episode { get; set; }

		public int ID { get; set; }

		public int Positive { get; set; }

		public int Rating { get; set; }

		public int State { get; set; }

		public int TID { get; set; }

		public int TimeStamp { get; set; }

		public Medium Medium { get; set; }

		public int UID { get; set; }

		public string Username { get; set; }

		public string Name { get; set; }

		#endregion Public Properties
	}
}