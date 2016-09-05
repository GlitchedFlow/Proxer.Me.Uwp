using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxer.Me.ProxData.Messenger.Data
{
	public class MessageData
	{
		[JsonProperty("Message_ID")]
		public int MessageID { get; set; }
		[JsonProperty("Conference_ID")]
		public int ConferenceID { get; set; }
		[JsonProperty("User_ID")]
		public int UserID { get; set; }
		public string Username { get; set; }
		public string Message { get; set; }
		public string Action { get; set; }
		public DateTime TimeStampe { get; set; }
		public string Device { get; set; }
	}
}
