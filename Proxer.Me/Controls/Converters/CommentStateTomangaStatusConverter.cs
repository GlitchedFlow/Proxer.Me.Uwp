using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class CommentStateToMangaStatusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var index = (int)value;
			switch (index)
			{
				case 0:
					return "Gelesen";
				case 1:
					return "Am lesen";
				case 2:
					return "Wird noch gelesen";
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
