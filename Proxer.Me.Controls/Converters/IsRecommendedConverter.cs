using System;
using Proxer.Me.Support.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class IsRecommendedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			IRateable Data = (IRateable)value;
			if (Data == null)
				return Visibility.Collapsed;
			if (Data.RateCount == 0)
				return Visibility.Collapsed;
			if (System.Convert.ToBoolean(parameter))
				return ((double)Data.RateSum / (double)Data.RateCount) >= ConverterDataProvider.RecommendationValue ? Visibility.Visible : Visibility.Collapsed;
			else
				return ((double)Data.RateSum / (double)Data.RateCount) >= ConverterDataProvider.RecommendationValue ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}