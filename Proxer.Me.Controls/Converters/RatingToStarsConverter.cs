using System;
using System.Collections.Generic;
using Proxer.Me.Support.Interfaces;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class RatingToStarsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var result = new List<double>();
			IRateable Data = (IRateable)value;
			if (value == null)
				return result;
			double rating = Data.RateSum / (double)Data.RateCount;
			int index = 0;
			while (rating > 1)
			{
				result.Add(1.0);
				rating -= 1;
				index++;
			}
			result.Add(rating);
			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}