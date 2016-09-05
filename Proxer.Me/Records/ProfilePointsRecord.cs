using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.Records
{
	public class ProfilePointsRecord
	{
		public int Points { get; }

		public string Name { get; }

		public ProfilePointsRecord(string Name, int Points)
		{
			this.Name = Name;
			this.Points = Points;
		}
	}
}
