using System;
using Windows.UI.Xaml.Data;
using static Proxer.Me.Controls.Expander;

namespace Proxer.Me.Controls.Converters
{
	public class EntryGridItemExpanderDirectionConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (bool)value ? ExpanderDirection.Up : ExpanderDirection.Down;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}