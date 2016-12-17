namespace Proxer.Me.Support.Api.Data.Info
{
	public class Group
	{
		#region Public Properties

		public string Country { get; set; }

		public int ID { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public virtual int SortKey
		{
			get { return 0; }
		}

		#endregion Public Properties
	}
}