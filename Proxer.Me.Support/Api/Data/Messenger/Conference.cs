using Newtonsoft.Json;
using Template10.Mvvm;

namespace Proxer.Me.Support.Api.Data.Messenger
{
	public class Conference : BindableBase
	{
		#region Public Properties

		public int Count { get; set; }

		public int ID { get; set; }

		public string Image { get; set; }

		[JsonProperty("Group")]
		public bool IsGroup { get; set; }

		[JsonProperty("Read")]
		public bool IsRead { get; set; }

		public string Leader { get; set; }

		private int readCount;

		[JsonProperty("Read_MID")]
		public int ReadMessageID { get; set; }

		[JsonProperty("TimeStamp_End")]
		public int TimeStampEnd { get; set; }

		public string Topic { get; set; }

		[JsonProperty("Topic_Custom")]
		public string TopicCustom { get; set; }

		private string latestMessage;

		private string username;

		public string LatestMessage
		{
			get { return latestMessage; }
			set { Set(ref latestMessage, value); }
		}

		public string Username
		{
			get { return username; }
			set { Set(ref username, value); }
		}

		[JsonProperty("Read_Count")]
		public int ReadCount
		{
			get { return readCount; }
			set { Set(ref readCount, value); }
		}

		#endregion Public Properties
	}
}