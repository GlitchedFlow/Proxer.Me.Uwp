using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class BoolToLoginConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (bool)value ? "Logout" : "Login";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value.ToString() == "Logout" ? true : false;
		}
	}
}