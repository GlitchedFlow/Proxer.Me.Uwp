using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class StringToHosterImagesConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string collection = (string)value;
			List<string> result = new List<string>();
			if (collection == null)
			{
				result.Add($"ms-appx:///Assets/Proxer/Hosts/manga.png");
				return result;
			}
			foreach (var host in collection.Split(','))
			{
				result.Add($"https://proxer.me/images/hoster/{host}");
			}
			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
