using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class StateStringConverter : DependencyObject, IValueConverter
	{


		public bool IsAnime
		{
			get { return (bool)GetValue(IsAnimeProperty); }
			set { SetValue(IsAnimeProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsAnime.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsAnimeProperty =
			DependencyProperty.Register("IsAnime", typeof(bool), typeof(StateStringConverter), new PropertyMetadata(true));



		public object Convert(object value, Type targetType, object parameter, string language)
		{
			switch ((int)value)
			{
				case 0:
					if (IsAnime)
						return "Geschaut";
					else
						return "Gelesen";
				case 1:
					if (IsAnime)
						return "Am schauen";
					else
						return "Am lesen";
				case 2:
					if (IsAnime)
						return "Wird geschaut";
					else
						return "Wird gelesen";
				case 3:
					return "Abgebrochen";
				default:
					return "Unbekannt";
			}

		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
