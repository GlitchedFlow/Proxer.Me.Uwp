using System;
using System.Collections.Generic;
using System.Linq;
using Proxer.Me.Support.Api.Data.Common;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class UserListToGroupedListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			IEnumerable<List> relations = (IEnumerable<List>)value;
			if (relations != null)
				return relations.GroupBy(x => x.State);
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}