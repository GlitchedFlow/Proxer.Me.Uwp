using Newtonsoft.Json;
using Proxer.Me.Support.Enums.Data;

namespace Proxer.Me.Support.Api.Data.Common
{
	public class TopTen
	{
		#region Public Properties

		[JsonProperty("Kat")]
		public Category Category { get; set; }

		public int EID { get; set; }

		public int FID { get; set; }

		public Medium Medium { get; set; }

		public string Name { get; set; }

		#endregion Public Properties
	}
}