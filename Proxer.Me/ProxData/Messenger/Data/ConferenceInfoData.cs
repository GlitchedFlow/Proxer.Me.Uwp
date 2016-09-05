using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.ProxData.Messenger.Data
{
	public class ConferenceInfoData
	{
		public ConferenceData Conference { get; set; }
		public List<UserData> Users { get; set; }
	}
}
