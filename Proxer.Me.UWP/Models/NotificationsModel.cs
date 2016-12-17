using System.Collections.ObjectModel;
using Proxer.Me.Support.Api.Data.UCP;

namespace Proxer.Me.UWP.Models
{
	public class NotificationsModel : ProxerModel
	{
		private ObservableCollection<Reminder> notifications;

		public ObservableCollection<Reminder> Notifications
		{
			get { return notifications; }
			set { Set(ref notifications, value); }
		}
	}
}