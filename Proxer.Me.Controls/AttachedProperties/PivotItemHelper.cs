using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.AttachedProperties
{
	[Bindable]
	public static class PivotItemHelper
	{
		public static bool GetShowPivotItem(DependencyObject obj)
		{
			return (bool)obj.GetValue(ShowPivotItemProperty);
		}

		public static void SetShowPivotItem(DependencyObject obj, bool value)
		{
			obj.SetValue(ShowPivotItemProperty, value);
		}

		public static Pivot GetHost(DependencyObject obj)
		{
			return (Pivot)obj.GetValue(HostProperty);
		}

		public static void SetHost(DependencyObject obj, Pivot value)
		{
			obj.SetValue(HostProperty, value);
		}

		// Using a DependencyProperty as the backing store for Host. This enables animation, styling,
		// binding, etc...
		public static readonly DependencyProperty HostProperty =
			DependencyProperty.RegisterAttached("Host", typeof(Pivot), typeof(PivotItemHelper), new PropertyMetadata(null));

		// Using a DependencyProperty as the backing store for ShowPivotItem. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty ShowPivotItemProperty =
			DependencyProperty.RegisterAttached("ShowPivotItem", typeof(bool), typeof(PivotItemHelper), new PropertyMetadata(true, showPivotItemChanged));

		private static void showPivotItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PivotItem item = d as PivotItem;
			if (item != null)
			{
				if (GetHost(item) != null)
				{
					SetVisibility(item);
				}
				else
				{
					item.Loaded += Item_Loaded;
				}
			}
		}

		private static void Item_Loaded(object sender, RoutedEventArgs e)
		{
			PivotItem item = sender as PivotItem;
			item.Loaded -= Item_Loaded;
			SetVisibility(item);
		}

		private static void SetVisibility(PivotItem item)
		{
			Pivot parent = null;
			if (GetHost(item) != null)
			{
				parent = GetHost(item);
			}
			else if (item != null)
			{
				parent = item.Parent as Pivot;
			}
			if (parent != null)
			{
				if (!GetShowPivotItem(item))
				{
					if (parent.Items.Contains(item))
					{
						SetHost(item, parent);
						parent.Items.Remove(item);
					}
				}
				else
				{
					int targetIndex = GetTargetIndex(item);
					if (parent.Items.Contains(item))
						return;
					parent.Items.Insert(targetIndex, item);
				}
			}
		}

		public static int GetTargetIndex(DependencyObject obj)
		{
			return (int)obj.GetValue(TargetIndexProperty);
		}

		public static void SetTargetIndex(DependencyObject obj, int value)
		{
			obj.SetValue(TargetIndexProperty, value);
		}

		// Using a DependencyProperty as the backing store for TargetIndex. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty TargetIndexProperty =
			DependencyProperty.RegisterAttached("TargetIndex", typeof(int), typeof(PivotItemHelper), new PropertyMetadata(0));
	}
}