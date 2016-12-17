﻿using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class TagStateToGroupNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int state = (int)value;
			if (state == 0)
				return "Eingetragene Tags";
			else if (state == 1)
				return "Unbewertete Tags";
			return "Spoiler Tags";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}