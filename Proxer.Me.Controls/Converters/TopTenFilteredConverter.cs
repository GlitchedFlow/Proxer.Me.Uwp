using System;
using System.Collections.Generic;
using System.Linq;
using Proxer.Me.Support.Api.Data.Common;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class TopTenFilteredConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			IEnumerable<TopTen> topTen = (IEnumerable<TopTen>)value;
			if (topTen != null)
			{
				if (parameter != null)
				{
					string category = (string)parameter;
					if (category != null)
					{
						return topTen.Where(x => x.Category.ToString().ToLower() == category);
					}
				}
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}