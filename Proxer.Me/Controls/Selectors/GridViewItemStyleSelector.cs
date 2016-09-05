using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Controls.Selectors
{
	public class GridViewItemStyleSelector : StyleSelector
	{
		public Style AutoSize { get; set; }

		protected override Style SelectStyleCore(object item, DependencyObject container)
		{
			return AutoSize;
		}
	}
}
