using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class InvertedBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (bool)value == true ? false : true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return (bool)value == true ? false : true;
		}
	}
}
