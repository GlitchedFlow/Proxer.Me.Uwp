using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.Records
{
	public class TopTenRecord
	{
		public int ID { get; }

		public string Cover
		{
			get
			{
				return $"http://cdn.proxer.me/cover/{ID}.jpg";
			}
		}

		public TopTenRecord(int id)
		{
			ID = id;
		}
	}
}
