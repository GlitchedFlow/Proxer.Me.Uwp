using System;
using System.Collections.Generic;
using Proxer.Me.Support.Interfaces;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class UserRatingToStarsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var result = new List<int>();
			int Data = (int)value;
			int index = 0;
			while (Data > 1)
			{
				result.Add(1);
				Data -= 1;
				index++;
			}
			result.Add(Data);
			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}