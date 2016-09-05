using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.Messenger.Data
{
	public class ConferenceData
	{
		public int ID { get; set; }

		public string Topic { get; set; }

		[JsonProperty("Topic_Custom")]
		public string TopicCustom { get; set; }
		public int Count { get; set; }
		[JsonProperty("Group")]
		public bool IsGroup { get; set; }
		[JsonProperty("TimeStamp_End")]
		public int TimeStampEnd { get; set; }
		[JsonProperty("Read")]
		public bool IsRead { get; set; }
		[JsonProperty("Read_Count")]
		public int ReadCount { get; set; }
		[JsonProperty("Read_MID")]
		public int ReadMessageID { get; set; }
		public string Image { get; set; }
		public string Leader { get; set; }
	}
}
