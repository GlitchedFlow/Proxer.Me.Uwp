using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.Records
{
	public class EntryContentPageRecord
	{
		public int Page { get; }

		public string Content { get; }

		public EntryContentPageRecord(int Page, string Content)
		{
			this.Page = Page;
			this.Content = Content;
		}
	}
}
