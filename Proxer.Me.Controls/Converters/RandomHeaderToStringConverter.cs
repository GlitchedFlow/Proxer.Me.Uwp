using System;
using Proxer.Me.Support.Api.Data.Media;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class RandomHeaderToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			RandomHeader header = (RandomHeader)value;
			if (header != null)
			{
				return $"https://cdn.proxer.me/gallery/originals/{header.CatPath}/{header.ImgFileName}";
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}