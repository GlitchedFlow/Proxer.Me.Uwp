using System;
using Newtonsoft.Json;

namespace Proxer.Me.Support.Api.Data.Info
{
	public class Tag
	{
		#region Public Properties

		public string Description { get; set; }

		public int ID { get; set; }

		[JsonProperty("Rate_Flag")]
		public int RateFlag { get; set; }

		[JsonProperty("Spoiler_Flag")]
		public int SpoilerFlag { get; set; }

		[JsonProperty("Tag")]
		public string Name { get; set; }

		public int TID { get; set; }

		public DateTime TimeStamp { get; set; }

		public int TagState
		{
			get
			{
				int state = 0;
				if (RateFlag == 0)
					state = 1;
				else if (SpoilerFlag == 1)
					state = 2;
				return state;
			}
		}

		#endregion Public Properties
	}
}