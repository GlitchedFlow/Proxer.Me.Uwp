using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.Notification.Data;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.Notification
{
	public class News : CoreData
	{
		public List<NewsData> Data { get; set; }
	}
}
