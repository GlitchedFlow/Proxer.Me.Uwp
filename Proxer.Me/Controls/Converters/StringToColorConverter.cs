using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class StringToColorConverter : IValueConverter
	{
		static StringToColorConverter()
		{
			Instance = new StringToColorConverter();
		}

		public static StringToColorConverter Instance { get; private set; }

		public Color GetColorFromHex(string hexString)
		{			
			byte a = byte.Parse(hexString.Substring(1, 2), NumberStyles.HexNumber);
			byte r = byte.Parse(hexString.Substring(3, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hexString.Substring(5, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hexString.Substring(7, 2), NumberStyles.HexNumber);

			return Color.FromArgb(a, r, g, b);
		}

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return GetColorFromHex(value.ToString());
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value.ToString();
		}
	}
}
