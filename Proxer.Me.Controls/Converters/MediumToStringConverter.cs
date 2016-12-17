using System;
using Proxer.Me.Support.Enums.Data;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class MediumToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Medium medium = (Medium)value;
			switch (medium)
			{
				case Medium.AnimeSeries:
					return "Animeserie";

				case Medium.MangaSeries:
					return "Mangaserie";

				case Medium.OneShot:
					return "One-Shot";

				case Medium.Doujin:
					return "Doujinshi";

				default:
					return medium.ToString();
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}