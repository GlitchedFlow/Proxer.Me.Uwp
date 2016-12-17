using System;
using System.Collections.Generic;
using System.Linq;
using Proxer.Me.Support.Api.Data.UCP;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class ReminderFilteredConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			IEnumerable<Reminder> reminder = (IEnumerable<Reminder>)value;
			if (reminder != null)
			{
				if (parameter != null)
				{
					string category = (string)parameter;
					if (category != null)
					{
						return reminder.Where(x => x.Category == category);
					}
				}
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}