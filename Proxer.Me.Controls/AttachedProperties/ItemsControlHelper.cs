using Proxer.Me.Controls.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Controls.AttachedProperties
{
	public static class ItemsControlHelper
	{
		public static bool GetAutoScrollToBottom(DependencyObject obj)
		{
			return (bool)obj.GetValue(AutoScrollToBottomProperty);
		}

		public static void SetAutoScrollToBottom(DependencyObject obj, bool value)
		{
			obj.SetValue(AutoScrollToBottomProperty, value);
		}

		// Using a DependencyProperty as the backing store for AutoScrollToBottom. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty AutoScrollToBottomProperty =
			DependencyProperty.RegisterAttached("AutoScrollToBottom", typeof(bool), typeof(ItemsControlHelper), new PropertyMetadata(false, AutoScrollToBottomChanged));

		private static ScrollViewer GetScrollViewer(DependencyObject obj)
		{
			return (ScrollViewer)obj.GetValue(ScrollViewerProperty);
		}

		private static void SetScrollViewer(DependencyObject obj, ScrollViewer value)
		{
			obj.SetValue(ScrollViewerProperty, value);
		}

		// Using a DependencyProperty as the backing store for ScrollViewer. This enables animation,
		// styling, binding, etc...
		private static readonly DependencyProperty ScrollViewerProperty =
			DependencyProperty.RegisterAttached("ScrollViewer", typeof(ScrollViewer), typeof(ItemsControlHelper), new PropertyMetadata(null));

		private static void AutoScrollToBottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ItemsControl control = (ItemsControl)d;
			if (GetAutoScrollToBottom(control))
			{
				control.Loaded += Control_Loaded;
				control.SizeChanged += Control_SizeChanged;
			}
			else
			{
				control.Loaded -= Control_Loaded;
				SetScrollViewer(control, null);
				control.SizeChanged += Control_SizeChanged;
			}
		}

		private static void Control_Loaded(object sender, RoutedEventArgs e)
		{
			SetScrollViewer((DependencyObject)sender, (sender as DependencyObject).GetFirstAncestorOfType<ScrollViewer>());
		}

		private static void Control_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			ScrollViewer viewer = GetScrollViewer((DependencyObject)sender);
			viewer?.ChangeView(0.0d, viewer.ScrollableHeight, 1.0f);
		}
	}
}