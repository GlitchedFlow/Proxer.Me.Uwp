using System;
using Proxer.Me.Support.Enums.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class RatingStyleVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			RatingStyle style = (RatingStyle)value;
			int demandedStyle = System.Convert.ToInt32(parameter);
			switch (demandedStyle)
			{
				case 0:
					if (style == RatingStyle.Progress | style == RatingStyle.StarsProgress)
						return Visibility.Visible;
					break;

				case 1:
					if (style == RatingStyle.Recommendation)
						return Visibility.Visible;
					break;

				case 2:
					if (style == RatingStyle.Stars | style == RatingStyle.StarsProgress)
						return Visibility.Visible;
					break;
			}
			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}