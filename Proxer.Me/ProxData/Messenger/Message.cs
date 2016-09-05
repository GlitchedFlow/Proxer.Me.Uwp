using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.Messenger.Data;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.Messenger
{
	public class Messages : CoreData
	{
		public List<MessageData> Data { get; set; }
	}
}
