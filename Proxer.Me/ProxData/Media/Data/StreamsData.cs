using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.ProxData.Media.Data
{
	public class StreamsData
	{
		public int ID { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string Img { get; set; }
		public int Uploader { get; set; }
		public string Username { get; set; }
		public int TimeStamp { get; set; }
		public int? TID { get; set; }
		public string TName { get; set; }
		public string HType { get; set; }
		public int SID { get; set; }
		public string Replace { get; set; }
	}
}
