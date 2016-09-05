using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.Core
{
	public static class VisualRunner
	{
		public static IEnumerable<DependencyObject> GetDescendants(DependencyObject start)
		{
			var queue = new Queue<DependencyObject>();
			var count = VisualTreeHelper.GetChildrenCount(start);

			for (int i = 0; i < count; i++)
			{
				var child = VisualTreeHelper.GetChild(start, i);
				yield return child;
				queue.Enqueue(child);
			}

			while (queue.Count > 0)
			{
				var parent = queue.Dequeue();
				var count2 = VisualTreeHelper.GetChildrenCount(parent);

				for (int i = 0; i < count2; i++)
				{
					var child = VisualTreeHelper.GetChild(parent, i);
					yield return child;
					queue.Enqueue(child);
				}
			}
		}

		public static DependencyObject GetFirstChildOfType<T>(DependencyObject start)
		{
			if (start is T) return start;

			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(start); i++)
			{
				var child = VisualTreeHelper.GetChild(start, i);

				var result = GetFirstChildOfType<T>(child);
				if (result != null) return result;
			}
			return null;
		}
	}
}
