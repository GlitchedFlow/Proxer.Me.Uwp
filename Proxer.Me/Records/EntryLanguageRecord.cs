using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.Records
{
	public class EntryLanguageRecord
	{
		public string Language { get; }

		public int Column { get; }

		public EntryLanguageRecord(string language, int column)
		{
			Language = language.ToUpper();
			Column = column;
		}
	}
}
