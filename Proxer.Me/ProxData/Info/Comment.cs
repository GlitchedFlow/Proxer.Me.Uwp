using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.Info.Data;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.Info
{
	public class Comment : CoreData
	{
		public List<CommentData> Data { get; set; }
	}
}
