using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.User.Data
{
	public class ListData
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }
		public Medium Medium { get; set; }
		[JsonProperty("EState")]
		public int State { get; set; }
		public int CID { get; set; }
		public string Comment { get; set; }
		[JsonProperty("State")]
		public int CommentState { get; set; }
		public int Episode { get; set; }
		public object Data { get; set; }
		public int Rating { get; set; }
		public int TimeStamp { get; set; }
	}
}
