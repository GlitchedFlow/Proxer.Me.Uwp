using System.Windows.Input;
using Proxer.Me.Support.Api.Data.UCP;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Mvvm;

namespace Proxer.Me.UWP.ViewModels
{
	public class NotificationsViewModel : ProxerViewModel<NotificationsModel>
	{
		public ICommand OpenContent { get; private set; }

		public ICommand DeleteNotification { get; private set; }

		public NotificationsViewModel() : base(new NotificationsModel())
		{
			OpenContent = new DelegateCommand<Reminder>(ExecuteOpenContent);
		}

		private async void ExecuteOpenContent(Reminder content)
		{
			Notifications.ShowNotifications(false, 0);
			content.ID = content.EID;
			if (content.Category == "anime")
			{
				await BootStrapper.Current.NavigationService.NavigateAsync(typeof(AnimePlayerPage), content);
			}
			else
			{
				await BootStrapper.Current.NavigationService.NavigateAsync(typeof(MangaReaderPage), content);
			}
		}
	}
}