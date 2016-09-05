using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.Controls.AttachedProperties
{
	public class HubHelper
	{


		public static object GetItemsSource(DependencyObject obj)
		{
			return (object)obj.GetValue(ItemsSourceProperty);
		}

		public static void SetItemsSource(DependencyObject obj, object value)
		{
			obj.SetValue(ItemsSourceProperty, value);
		}

		// Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ItemsSourceProperty =
			DependencyProperty.RegisterAttached("ItemsSource", typeof(object), typeof(HubHelper), new PropertyMetadata(null, ItemsSourceChanged));

		private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var hub = d as Hub;
			hub.Sections.Clear();
			if (e.NewValue != null)
			{
				if (e.NewValue is IEnumerable<object>)
				{
					foreach (var item in e.NewValue as IEnumerable<object>)
					{
						hub.Sections.Add(new HubSection() { DataContext = item, ContentTemplate = hub.Resources.Last().Value as DataTemplate });
					}
				}
			}
		}
	}
}
