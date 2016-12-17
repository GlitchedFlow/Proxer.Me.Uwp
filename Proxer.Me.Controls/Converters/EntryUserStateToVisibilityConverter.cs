using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class EntryUserStateToVisibilityConverter : DependencyObject, IValueConverter
	{


		public int Number
		{
			get { return (int)GetValue(NumberProperty); }
			set { SetValue(NumberProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty NumberProperty =
			DependencyProperty.Register("Number", typeof(int), typeof(EntryUserStateToVisibilityConverter), new PropertyMetadata(0));



		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int state = (int)value;
			if (state == 0)
				return Visibility.Collapsed;
			return state >= Number ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
