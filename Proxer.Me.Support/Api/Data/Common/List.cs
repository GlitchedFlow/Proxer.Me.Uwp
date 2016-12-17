using Proxer.Me.Support.Enums.Data;
using Template10.Mvvm;

namespace Proxer.Me.Support.Api.Data.Common
{
	public class List : BindableBase
	{
		#region Public Properties

		public int CID { get; set; }

		public string Comment { get; set; }

		public int Count { get; set; }

		public object Data { get; set; }

		public int Episode { get; set; }

		public int EState { get; set; }

		public int ID { get; set; }

		public Medium Medium { get; set; }

		public string Name { get; set; }

		public int Rating { get; set; }

		public int State { get; set; }

		#endregion Public Properties
	}
}