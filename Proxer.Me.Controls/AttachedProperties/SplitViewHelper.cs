using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Controls.AttachedProperties
{
	public static class SplitViewHelper
	{
		public static bool GetIsFullScreen(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsFullScreenProperty);
		}

		public static void SetIsFullScreen(DependencyObject obj, bool value)
		{
			obj.SetValue(IsFullScreenProperty, value);
		}

		private static IDictionary<SplitView, long> tokenCache = new Dictionary<SplitView, long>();

		// Using a DependencyProperty as the backing store for IsFullScreen. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty IsFullScreenProperty =
			DependencyProperty.RegisterAttached("IsFullScreen", typeof(bool), typeof(SplitViewHelper), new PropertyMetadata(false, isFullScreenChanged));

		private static void isFullScreenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SplitView view = (SplitView)d;
			if (view != null)
			{
				bool fullScreen = GetIsFullScreen(view);
				if (fullScreen && !tokenCache.ContainsKey(view))
					tokenCache.Add(view, view.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, IsPaneOpenPropertyChanged));
				else
				{
					if (tokenCache.ContainsKey(view))
					{
						view.UnregisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, tokenCache[view]);
						tokenCache.Remove(view);
					}
				}
			}
		}

		private static void IsPaneOpenPropertyChanged(DependencyObject sender, DependencyProperty dp)
		{
			SplitView view = sender as SplitView;
			if (view.IsPaneOpen)
			{
				if (Window.Current.Bounds.Width <= GetFullScreenMaxWidth(view))
				{
					view.OpenPaneLength = Window.Current.Bounds.Width;
				}
				else
				{
					view.OpenPaneLength = GetOpenPaneLength(view);
				}
			}
		}

		public static double GetFullScreenMaxWidth(DependencyObject obj)
		{
			return (double)obj.GetValue(FullScreenMaxWidthProperty);
		}

		public static void SetFullScreenMaxWidth(DependencyObject obj, double value)
		{
			obj.SetValue(FullScreenMaxWidthProperty, value);
		}

		// Using a DependencyProperty as the backing store for FullScreenMaxWidth. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty FullScreenMaxWidthProperty =
			DependencyProperty.RegisterAttached("FullScreenMaxWidth", typeof(double), typeof(SplitViewHelper), new PropertyMetadata(500));

		public static double GetOpenPaneLength(DependencyObject obj)
		{
			return (double)obj.GetValue(OpenPaneLengthProperty);
		}

		public static void SetOpenPaneLength(DependencyObject obj, double value)
		{
			obj.SetValue(OpenPaneLengthProperty, value);
		}

		// Using a DependencyProperty as the backing store for OpenPaneLength. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty OpenPaneLengthProperty =
			DependencyProperty.RegisterAttached("OpenPaneLength", typeof(double), typeof(SplitView), new PropertyMetadata(250));
	}
}