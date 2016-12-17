using System;
using System.Collections.Generic;
using System.Linq;
using Proxer.Me.Support.Api.Data.Info;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class PeopleToGroupedPeopleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			List<Group> data = (List<Group>)value;
			if (data != null)
			{
				return data.OrderBy(x => x.Name).GroupBy(x => x.SortKey);
			}
			return data;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}