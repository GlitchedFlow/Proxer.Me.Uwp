using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Template10.Common;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class ShellViewModel : ProxerViewModel<ShellModel>
	{
		public ICommand ShowNotifications { get; private set; }

		#region Public Constructors

		public ShellViewModel() : base(new ShellModel())
		{
			if (Windows.Storage.ApplicationData.Current.LocalSettings.Values["Token"] != null)
			{
				ProxerClient.Client.DefaultRequestHeaders.Add("proxer-api-token", (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["Token"]);
				Model.GlobalToken = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["Token"];
			}
			ShowNotifications = new DelegateCommand(ExecuteShowNotifications);
		}

		#endregion Public Constructors

		private void ExecuteShowNotifications()
		{
			Notifications.ShowNotifications(true, Model.ShellModel.UnreadNotificationsCount);
		}

		public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			if (parameter == null)
				BootStrapper.Current.NavigationService.GoBack();

			return base.OnNavigatedToAsync(parameter, mode, state);
		}
	}
}