using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class MessageTimeStampConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int dateTime = (int)value;
			TimeSpan messageTimeSpan = TimeSpan.FromDays(dateTime);
			TimeSpan nowTimeSpawn = TimeSpan.FromDays(TimeSpan.FromTicks(DateTime.Now.Ticks).Days);
			if (nowTimeSpawn.Days - messageTimeSpan.Days == 0)
				return "Heute";
			else if (nowTimeSpawn.Days - messageTimeSpan.Days == 1)
				return "Gestern";
			else if (nowTimeSpawn.Days - messageTimeSpan.Days > 1 && nowTimeSpawn.Days - messageTimeSpan.Days < 7)
			{
				return new DateTime(messageTimeSpan.Ticks).ToString("dddd");
			}
			return new DateTime(messageTimeSpan.Ticks).ToString("dd.MM.yyyy");
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}