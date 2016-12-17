using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class LanguageToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value.ToString() == "en")
				return "Englisch";
			else if (value.ToString() == "engsub")
				return "EngSub";
			else if (value.ToString() == "engdub")
				return "EngDub";
			else if (value.ToString() == "de")
				return "Deutsch";
			else if (value.ToString() == "gerdub")
				return "GerDub";
			else if (value.ToString() == "gersub")
				return "GerSub";
			else
				return "Unknown";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}