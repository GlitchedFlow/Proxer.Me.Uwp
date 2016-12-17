using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Controls.AttachedProperties
{
	public static class ScrollViewHelper
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
			DependencyProperty.RegisterAttached("AutoScrollToBottom", typeof(bool), typeof(ScrollViewHelper), new PropertyMetadata(false, AutoScrollToBottomChanged));

		private static void AutoScrollToBottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewer viewer = (ScrollViewer)d;
			viewer?.ChangeView(0.0d, double.MaxValue, 1.0f);
		}
	}
}