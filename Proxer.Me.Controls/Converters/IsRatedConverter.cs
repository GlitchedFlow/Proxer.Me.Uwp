using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class IsRatedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int count = (int)value;
			if ((bool)System.Convert.ToBoolean(parameter))
				return count > 0 ? Visibility.Visible : Visibility.Collapsed;
			else
				return count > 0 ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}