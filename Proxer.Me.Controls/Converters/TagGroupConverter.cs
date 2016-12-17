using System;
using System.Collections.Generic;
using System.Linq;
using Proxer.Me.Support.Api.Data.Info;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class TagGroupConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			List<Tag> tags = (List<Tag>)value;
			if (tags != null)
				return tags.OrderBy(x => x.Name).GroupBy(x => x.TagState);
			return new List<object>();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}