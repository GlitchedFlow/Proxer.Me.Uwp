using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class StateImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int state = (int)value;
			switch (state)
			{
				case 0:
				case 3:
					return "ms-appx:///Assets/Proxer/Status/abgebrochen.png";

				case 1:
				case 4:
					return "ms-appx:///Assets/Proxer/Status/abgeschlossen.png";

				case 2:
					return "ms-appx:///Assets/Proxer/Status/airing.png";
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}