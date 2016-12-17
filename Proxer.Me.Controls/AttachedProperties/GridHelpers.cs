using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Controls.AttachedProperties
{
	public static class GridHelpers
	{




		public static int GetColumnsCount(DependencyObject obj)
		{
			return (int)obj.GetValue(ColumnsCountProperty);
		}

		public static void SetColumnsCount(DependencyObject obj, int value)
		{
			obj.SetValue(ColumnsCountProperty, value);
		}

		// Using a DependencyProperty as the backing store for ColumnsCount.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ColumnsCountProperty =
			DependencyProperty.RegisterAttached("ColumnsCount", typeof(int), typeof(GridHelpers), new PropertyMetadata(0, ColumnsCountPropertyChanged));

		private static void ColumnsCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as Grid).ColumnDefinitions.Clear();
			for (int i = 0; i < (int)e.NewValue; i++)
			{
				if (GetAutoWidth(d))
				{
					(d as Grid).ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Auto) });
				}
				else
				{
					(d as Grid).ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
				}
			}
		}



		public static bool GetAutoWidth(DependencyObject obj)
		{
			return (bool)obj.GetValue(AutoWidthProperty);
		}

		public static void SetAutoWidth(DependencyObject obj, bool value)
		{
			obj.SetValue(AutoWidthProperty, value);
		}

		// Using a DependencyProperty as the backing store for AutoWidth.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AutoWidthProperty =
			DependencyProperty.RegisterAttached("AutoWidth", typeof(bool), typeof(GridHelpers), new PropertyMetadata(false));




		public static bool GetColumnForce(DependencyObject obj)
		{
			return (bool)obj.GetValue(ColumnForceProperty);
		}

		public static void SetColumnForce(DependencyObject obj, bool value)
		{
			obj.SetValue(ColumnForceProperty, value);
		}

		// Using a DependencyProperty as the backing store for ColumnForce.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ColumnForceProperty =
			DependencyProperty.RegisterAttached("ColumnForce", typeof(bool), typeof(GridHelpers), new PropertyMetadata(false, ColumnForcePropertyChanged));

		private static void ColumnForcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Grid grid = d as Grid;

			// construct the required row definitions
			grid.LayoutUpdated += (s, e2) =>
			{
				var childCount = grid.Children.Count;

				// set the row property for each chid
				for (int i = 0; i < childCount; i++)
				{
					var child = grid.Children[i] as FrameworkElement;
					Grid.SetColumn(child, i);
				}
			};
		}
	}
}
