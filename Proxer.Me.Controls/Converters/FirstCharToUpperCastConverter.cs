using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class FirstCharToUpperCastConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string target = (string)value;
			if (target != null)
			{
				char firstChar = target[0];
				return target.Remove(0, 1).Insert(0, char.ToUpper(firstChar).ToString());
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}