using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.User.Data;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.User
{
	public class Comments : CoreData
	{
		public List<CommentsData> Data { get; set; }
	}
}
