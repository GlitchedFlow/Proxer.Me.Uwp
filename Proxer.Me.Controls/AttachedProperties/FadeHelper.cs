using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace Proxer.Me.Controls.AttachedProperties
{
	public class FadeHelper
	{
		public static bool GetVisibility(DependencyObject obj)
		{
			return (bool)obj.GetValue(VisibilityProperty);
		}

		public static void SetVisibility(DependencyObject obj, bool value)
		{
			obj.SetValue(VisibilityProperty, value);
		}

		// Using a DependencyProperty as the backing store for Visibility.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty VisibilityProperty =
			DependencyProperty.RegisterAttached("Visibility", typeof(bool), typeof(FadeHelper), new PropertyMetadata(true, VisibilityPropertyChanged));


		public static double GetVisibleOpacity(DependencyObject obj)
		{
			return (double)obj.GetValue(VisibleOpacityProperty);
		}

		public static void SetVisibleOpacity(DependencyObject obj, double value)
		{
			obj.SetValue(VisibleOpacityProperty, value);
		}

		// Using a DependencyProperty as the backing store for VisibleOpacity.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty VisibleOpacityProperty =
			DependencyProperty.RegisterAttached("VisibleOpacity", typeof(double), typeof(FadeHelper), new PropertyMetadata(1.0));

		private static void VisibilityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var newValue = (bool)e.NewValue;
			var frameElement = d as FrameworkElement;
			if (frameElement != null)
			{
				var storyboard = new Storyboard();
				var animation = new DoubleAnimation();
				Storyboard.SetTarget(animation, d);
				Storyboard.SetTargetProperty(animation, "(UIElement.Opacity)");
				if (newValue)
				{
					frameElement.Visibility = Visibility.Visible;
					animation.From = 0.0;
					animation.To = GetVisibleOpacity(d);
					animation.Duration = new Duration(TimeSpan.FromSeconds(.35));
				}
				else
				{
					animation.From = GetVisibleOpacity(d);
					animation.To = 0.0;
					animation.Duration = new Duration(TimeSpan.FromSeconds(.35));
				}
				storyboard.Children.Add(animation);
				storyboard.Begin();
				if (!newValue)
					storyboard.Completed += delegate { frameElement.Visibility = Visibility.Collapsed; };
			}
		}
	}
}
