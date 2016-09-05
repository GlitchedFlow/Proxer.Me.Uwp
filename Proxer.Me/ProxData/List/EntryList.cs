using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.List.Data;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxData.List
{
	public class EntryList : CoreData
	{
		public List<EntryListData> Data { get; set; }
	}
}
