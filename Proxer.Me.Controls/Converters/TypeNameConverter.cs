using System;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class TypeNameConverter : IValueConverter
	{
		private const string synonym = "Synonym";

		private const string japanese = "Jap. Titel";

		private const string english = "Eng. Titel";

		private const string german = "Deu. Titel";

		private const string original = "Original Titel";

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string type = (string)value;
			if (type != null)
			{
				if (type.StartsWith("sy"))
					return synonym;
				else if (type.EndsWith("jap"))
					return japanese;
				else if (type.EndsWith("eng"))
					return english;
				else if (type.EndsWith("ger"))
					return german;
				return original;
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}