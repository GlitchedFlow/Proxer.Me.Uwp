using System.Collections.Generic;

namespace Proxer.Me.Support.Api.Data.Manga
{
	public class Chapter
	{
		#region Public Properties

		public int CID { get; set; }

		public int EID { get; set; }

		public List<string[]> Pages { get; set; }

		public string Server { get; set; }

		public int? TID { get; set; }

		public int TimeStamp { get; set; }

		public string Title { get; set; }

		public string TName { get; set; }

		public int Uploader { get; set; }

		public string Username { get; set; }

		#endregion Public Properties
	}
}