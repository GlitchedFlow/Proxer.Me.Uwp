using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class PeopleSortKeyToNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int sortKey = (int)value;
			return sortKey == 0 ? "Gruppen" : "Industrie";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}