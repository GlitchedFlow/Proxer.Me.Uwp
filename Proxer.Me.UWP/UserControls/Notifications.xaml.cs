using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.UCP;
using Template10.Common;
using Template10.Controls;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Proxer.Me.UWP.UserControls
{
	public sealed partial class Notifications : UserControl
	{
		public Notifications()
		{
			this.InitializeComponent();
			NotificationsCollection = new ObservableCollection<Reminder>();
			CloseCommand = new DelegateCommand(ExecuteCloseCommand);
		}

		private void ExecuteCloseCommand()
		{
			ShowNotifications(false);
		}

		public ObservableCollection<Reminder> NotificationsCollection
		{
			get { return (ObservableCollection<Reminder>)GetValue(NotificationsCollectionProperty); }
			set { SetValue(NotificationsCollectionProperty, value); }
		}

		// Using a DependencyProperty as the backing store for NotificationsCollection. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty NotificationsCollectionProperty =
			DependencyProperty.Register("NotificationsCollection", typeof(ObservableCollection<Reminder>), typeof(Notifications), new PropertyMetadata(null));

		public ICommand CloseCommand
		{
			get { return (ICommand)GetValue(CloseCommandProperty); }
			set { SetValue(CloseCommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CloseCommand. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty CloseCommandProperty =
			DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(Notifications), new PropertyMetadata(null));

		public static void ShowNotifications(bool visible, int count = 0)
		{
			WindowWrapper.Current().Dispatcher.Dispatch(async () =>
			{
				var modal = Window.Current.Content as ModalDialog;
				var view = modal.ModalContent as Notifications;
				if (view == null)
				{
					modal.ModalContent = view = new Notifications();
					await view.getNotifications(10);
				}
				modal.IsModal = visible;
			});
		}

		public async Task getNotifications(int count)
		{
			NotificationsCollection.Clear();
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("limit", count.ToString());
			ResponseData<List<Reminder>> response = await UCPAPI.GetReminder(postParas);
			if (response.Error)
			{
				Info.SetInfo(true, response.Message);
			}
			else
			{
				foreach (var reminder in response.Data)
				{
					NotificationsCollection.Add(reminder);
				}
			}
		}
	}
}