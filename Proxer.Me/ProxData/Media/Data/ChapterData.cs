using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.ProxData.Media.Data
{
	public class ChapterData
	{
		public int CID { get; set; }
		public int EID { get; set; }
		public string Title { get; set; }
		public int Uploader { get; set; }
		public string Username { get; set; }
		public int TimeStamp { get; set; }
		public int? TID { get; set; }
		public string TName { get; set; }
		public string Server { get; set; }
		public List<string[]> Pages { get; set; }
	}
}
