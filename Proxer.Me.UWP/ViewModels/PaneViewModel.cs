using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.UWP.Models;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class PaneViewModel<T> : ProxerViewModel<T> where T : PaneModel
	{
		public ICommand SwitchPaneState { get; private set; }

		public ICommand SizeChanged { get; private set; }

		public PaneViewModel(T model) : base(model)
		{
			SwitchPaneState = new DelegateCommand(ExecuteSwitchPaneState);
			SizeChanged = new DelegateCommand(ExecuteSizeChanged);
			Window.Current.SizeChanged += Current_SizeChanged;
		}

		private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
		{
			SizeChanged.Execute(null);
		}

		private void ExecuteSizeChanged()
		{
			double width = Window.Current.Bounds.Width;
			if (width < Model.VisualStateWideMinWidth)
			{
				Model.IsPaneOpen = false;
				if (Model.IsThreeState)
				{
					if (width < Model.VisualStateNormalMinWidth)
					{
						Model.PaneDisplayMode = SplitViewDisplayMode.Overlay;
					}
					else
					{
						Model.PaneDisplayMode = SplitViewDisplayMode.CompactOverlay;
					}
				}
				else
				{
					Model.PaneDisplayMode = SplitViewDisplayMode.Overlay;
				}
			}
			else
			{
				Model.IsPaneOpen = true;
				Model.PaneDisplayMode = SplitViewDisplayMode.Inline;
			}
		}

		private void ExecuteSwitchPaneState()
		{
			double width = Window.Current.Bounds.Width;
			Model.IsPaneOpen = !Model.IsPaneOpen;
			if (Model.IsThreeState)
			{
				if (width < Model.VisualStateWideMinWidth)
				{
					if (width < Model.VisualStateNormalMinWidth)
					{
						Model.PaneDisplayMode = SplitViewDisplayMode.Overlay;
					}
					else
					{
						Model.PaneDisplayMode = SplitViewDisplayMode.CompactOverlay;
					}
				}
				else
				{
					Model.PaneDisplayMode = SplitViewDisplayMode.Inline;
				}
			}
			else
			{
				if (width < Model.VisualStateWideMinWidth)
				{
					Model.PaneDisplayMode = SplitViewDisplayMode.Overlay;
				}
				else
				{
					Model.PaneDisplayMode = SplitViewDisplayMode.Inline;
				}
			}
		}

		public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			SizeChanged.Execute(null);
			return base.OnNavigatedToAsync(parameter, mode, state);
		}
	}
}