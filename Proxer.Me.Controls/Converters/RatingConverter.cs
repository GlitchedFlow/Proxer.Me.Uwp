using System;
using Proxer.Me.Support.Interfaces;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class RatingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			IRateable Data = (IRateable)value;
			if (Data != null)
			{
				if (Data.RateCount == 0)
				{
					return "";
				}
				return ((double)Data.RateSum / (double)Data.RateCount).ToString("#.##");
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}