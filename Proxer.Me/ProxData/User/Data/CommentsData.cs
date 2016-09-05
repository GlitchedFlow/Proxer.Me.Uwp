using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.ProxData.User.Data
{
	public class CommentsData
	{
		public int ID { get; set; }
		public int TID { get; set; }
		public int State { get; set; }
		public object Data { get; set; }
		public string Comment { get; set; }
		public int Rating { get; set; }
		public int Episode { get; set; }
		public int Positive { get; set; }
		public int TimeStamp { get; set; }
		public string Username { get; set; }
		public int UID { get; set; }
		public string Avatar { get; set; }
	}
}
