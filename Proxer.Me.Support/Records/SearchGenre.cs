using System.Reflection;
using Proxer.Me.Support.Attributes;
using Proxer.Me.Support.Enums.Data;
using Template10.Mvvm;

namespace Proxer.Me.Support.Records
{
	public class SearchGenre : BindableBase
	{
		public Genre Genre { get; }

		public string DisplayName { get; }

		public bool? State
		{
			get { return _state; }
			set
			{
				Set(ref _state, value);
			}
		}

		private bool? _state = false;

		public SearchGenre(Genre genre)
		{
			Genre = genre;
			DisplayName = getDisplayName();
		}

		private string getDisplayName()
		{
			GenreNameAttribute attribute = Genre.GetType().GetRuntimeField(Genre.ToString()).GetCustomAttribute<GenreNameAttribute>();
			return attribute.DisplayName;
		}
	}
}