using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.Controls.Converters
{
	public class StateToReminderColorConverter : DependencyObject, IValueConverter
	{
		public Brush OnlineBrush
		{
			get { return (Brush)GetValue(OnlineBrushProperty); }
			set { SetValue(OnlineBrushProperty, value); }
		}

		// Using a DependencyProperty as the backing store for OnlineBrush. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty OnlineBrushProperty =
			DependencyProperty.Register("OnlineBrush", typeof(Brush), typeof(StateToReminderColorConverter), new PropertyMetadata(new SolidColorBrush(Colors.Green)));

		public Brush OfflineBrush
		{
			get { return (Brush)GetValue(OfflineBrushProperty); }
			set { SetValue(OfflineBrushProperty, value); }
		}

		// Using a DependencyProperty as the backing store for OfflineBrush. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty OfflineBrushProperty =
			DependencyProperty.Register("OfflineBrush", typeof(Brush), typeof(StateToReminderColorConverter), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			int state = (int)value;
			if (state == 1)
				return OnlineBrush;
			else
				return OfflineBrush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}