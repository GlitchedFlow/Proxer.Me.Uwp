using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.UCP.Data
{
	public class ListData
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }
		public Medium Medium { get; set; }
		public string EState { get; set; }
		public int CID { get; set; }
		public string Comment { get; set; }
		public int State { get; set; }
		public int Episode { get; set; }
		public object Data { get; set; }
		public int Rating { get; set; }

	}
}
