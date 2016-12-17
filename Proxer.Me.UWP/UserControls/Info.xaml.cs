using System.Windows.Input;
using Template10.Common;
using Template10.Controls;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Proxer.Me.UWP.UserControls
{
	public sealed partial class Info : UserControl
	{
		public Info()
		{
			this.InitializeComponent();
			CloseCommand = new DelegateCommand(ExecuteCloseCommand);
		}

		private void ExecuteCloseCommand()
		{
			WindowWrapper.Current().Dispatcher.Dispatch(() =>
			{
				var modal = Window.Current.Content as ModalDialog;
				var view = modal.ModalContent as Info;
				if (view == null)
					modal.ModalContent = view = new Info();
				modal.IsModal = false;
			});
		}

		public string InfoText
		{
			get { return (string)GetValue(InfoTextProperty); }
			set { SetValue(InfoTextProperty, value); }
		}

		// Using a DependencyProperty as the backing store for InfoText. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty InfoTextProperty =
			DependencyProperty.Register("InfoText", typeof(string), typeof(Info), new PropertyMetadata("Info..."));

		public ICommand CloseCommand
		{
			get { return (ICommand)GetValue(CloseCommandProperty); }
			set { SetValue(CloseCommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CloseCommand. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty CloseCommandProperty =
			DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(Info), new PropertyMetadata(null));

		public static void SetInfo(bool show, string text = null)
		{
			WindowWrapper.Current().Dispatcher.Dispatch(() =>
			{
				var modal = Window.Current.Content as ModalDialog;
				var view = modal.ModalContent as Info;
				if (view == null)
					modal.ModalContent = view = new Info();
				modal.IsModal = show;
				view.InfoText = text;
			});
		}
	}
}