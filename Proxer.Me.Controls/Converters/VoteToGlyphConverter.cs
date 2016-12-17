using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class VoteToGlyphConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			bool condition = System.Convert.ToBoolean(parameter);
			if (condition)
				return value.ToString() == "recommend" ? Visibility.Visible : Visibility.Collapsed;
			else
				return value.ToString() == "recommend" ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}