using System.Collections.Generic;

namespace Proxer.Me.Support.Api.Data.Messenger
{
	public class ConferenceInfo
	{
		#region Public Properties

		public Conference Conference { get; set; }

		public List<User> Users { get; set; }

		#endregion Public Properties
	}
}