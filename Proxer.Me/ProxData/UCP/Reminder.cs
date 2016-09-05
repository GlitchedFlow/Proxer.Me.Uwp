using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.UCP.Data;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.UCP
{
	public class Reminder : CoreData
	{
		public List<ReminderData> Data { get; set; }
	}
}
