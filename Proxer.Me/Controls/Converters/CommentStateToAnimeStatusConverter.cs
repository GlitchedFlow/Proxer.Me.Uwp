using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class CommentStateToAnimeStatusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var index = (int)value;
			switch (index)
			{
				case 0:
					return "Geschaut";
				case 1:
					return "Am schauen";
				case 2:
					return "Wird noch geschaut";
				case 3:
					return "Abgebrochen";
			}
			return "Unknown";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
