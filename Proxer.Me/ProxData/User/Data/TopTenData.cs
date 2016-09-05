using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.User.Data
{
	public class TopTenData
	{
		public int EID { get; set; }
		public string Name { get; set; }
		[JsonProperty("Kat")]
		public Category Category { get; set; }
		public Medium Medium { get; set; }
	}
}
