using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Support.Api.Data.Info;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class EpisodeTitleConverter : DependencyObject, IValueConverter
	{


		public FullEntry Entry
		{
			get { return (FullEntry)GetValue(EntryProperty); }
			set { SetValue(EntryProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Entry.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty EntryProperty =
			DependencyProperty.Register("Entry", typeof(FullEntry), typeof(EpisodeTitleConverter), new PropertyMetadata(null));



		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Episode episode = (Episode)value;
			if (episode == null | Entry == null)
				return "";

			if (episode.Title != null)
				return episode.Title;
			else
				return Entry.Name + " " + (Entry.Category == "anime" ? "Episode" : "Kapitel") + " " + episode.Number;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
