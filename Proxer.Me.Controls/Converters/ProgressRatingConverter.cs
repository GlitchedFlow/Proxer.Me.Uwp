using System;
using Proxer.Me.Support.Interfaces;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class ProgressRatingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			IRateable Data = (IRateable)value;
			if (Data != null)
			{
				if (Data.RateCount == 0)
				{
					return 100;
				}
				return 100 - ((100 * ((double)Data.RateSum / (double)Data.RateCount)) / 10);
			}
			return 0d;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}