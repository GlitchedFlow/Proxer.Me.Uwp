using Template10.Mvvm;

namespace Proxer.Me.Support.Records
{
	public class SearchTag : BindableBase
	{
		public string DisplayName { get; }

		public bool? State
		{
			get { return state; }
			set { Set(ref state, value); }
		}

		public int ID { get; }

		public string Description { get; }

		private bool? state = false;

		public char SortKey { get; }

		public SearchTag(string DisplayName, string Description, int ID)
		{
			this.DisplayName = DisplayName;
			this.Description = Description;
			if (!char.IsLetter(DisplayName[0]))
				SortKey = '#';
			else
				SortKey = DisplayName[0];
			this.ID = ID;
		}
	}
}