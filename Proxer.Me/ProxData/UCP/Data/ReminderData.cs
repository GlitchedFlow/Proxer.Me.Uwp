using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.UCP.Data
{
	public class ReminderData
	{
		public int EID { get; set; }
		[JsonProperty("Kat")]
		public string Category { get; set; }
		public string Name { get; set; }
		public int Episode { get; set; }
		public string Language { get; set; }
		public Medium Medium { get; set; }
		public int ID { get; set; }
		public string State { get; set; }
	}
}
