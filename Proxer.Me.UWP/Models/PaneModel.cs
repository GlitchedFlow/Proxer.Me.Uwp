using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.UWP.Models
{
	public class PaneModel : ProxerModel
	{
		public PaneModel()
		{
			VisualStateWideMinWidth = (double)Application.Current.Resources[nameof(VisualStateWideMinWidth)];
			VisualStateNormalMinWidth = (double)Application.Current.Resources[nameof(VisualStateNormalMinWidth)];
			VisualStateNarrowMinWidth = (double)Application.Current.Resources[nameof(VisualStateNarrowMinWidth)];
		}

		public double VisualStateWideMinWidth { get; }

		public double VisualStateNormalMinWidth { get; }

		public double VisualStateNarrowMinWidth { get; }

		private bool isPaneOpen;

		public bool IsPaneOpen
		{
			get { return isPaneOpen; }
			set { Set(ref isPaneOpen, value); }
		}

		public SplitViewDisplayMode PaneDisplayMode
		{
			get { return paneDisplayMode; }
			set { Set(ref paneDisplayMode, value); }
		}

		private SplitViewDisplayMode paneDisplayMode;

		public bool IsThreeState { get; set; } = false;
	}
}