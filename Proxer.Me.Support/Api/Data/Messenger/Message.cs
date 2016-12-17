using System;
using Newtonsoft.Json;

namespace Proxer.Me.Support.Api.Data.Messenger
{
	public class Message
	{
		#region Public Properties

		public string Action { get; set; }

		[JsonProperty("Conference_ID")]
		public int ConferenceID { get; set; }

		public string Device { get; set; }

		[JsonProperty("Message")]
		public string Text { get; set; }

		[JsonProperty("Message_ID")]
		public int MessageID { get; set; }

		public int TimeStamp { get; set; }

		[JsonProperty("User_ID")]
		public int UserID { get; set; }

		public string Username { get; set; }

		public Message PreviousMessage { get; set; }

		public bool IsGroupMessage { get; set; }

		public bool IsSendByMe { get; set; }

		public bool IsInfo { get; set; }

		public DateTime DateTime
		{
			get
			{
				System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
				dtDateTime = dtDateTime.AddSeconds(System.Convert.ToDouble(TimeStamp)).ToLocalTime();
				return dtDateTime;
			}
		}

		public bool ShowName
		{
			get
			{
				if (PreviousMessage == null)
					return true;
				return PreviousMessage.Username != Username;
			}
		}

		#endregion Public Properties
	}
}