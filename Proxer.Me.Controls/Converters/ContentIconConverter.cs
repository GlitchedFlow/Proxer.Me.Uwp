using System;
using Proxer.Me.Support.Api.Data.Info;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class ContentIconConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Episode episode = (Episode)value;
			if (episode.HosterImgs == null)
				return $"ms-appx:///Assets/Proxer/Hosts/manga.png";
			return $"ms-appx:///Assets/Proxer/Hosts/play.png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}