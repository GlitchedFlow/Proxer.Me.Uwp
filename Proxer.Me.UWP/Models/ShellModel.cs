using Proxer.Me.UWP.Core;

namespace Proxer.Me.UWP.Models
{
	public class ShellModel : ProxerModel
	{
		private string globalUsername;

		public string GlobalUsername
		{
			get { return globalUsername; }
			set { Set(ref globalUsername, value); }
		}

		public string GlobalToken { get; set; }

		private string globalAvatar;

		public bool IsUserLoggedIn
		{
			get { return isUserLoggedIn; }
			set
			{
				Set(ref isUserLoggedIn, value);
				RaisePropertyChanged(nameof(ShowAdultContent));
			}
		}

		public string GlobalAvatar
		{
			get { return globalAvatar; }
			set { Set(ref globalAvatar, value); }
		}

		public bool IsUserAdult
		{
			get { return isUserAdult; }
			set
			{
				Set(ref isUserAdult, value);
				RaisePropertyChanged(nameof(ShowAdultContent));
			}
		}

		public bool UseWebPlayer
		{
			get { return !DeviceAPI.AnimeAllowed(); }
		}

		public bool UseWebReader
		{
			get { return !DeviceAPI.MangaAllowed(); }
		}

		public bool ShowAdultContent
		{
			get { return isUserLoggedIn && IsUserAdult; }
		}

		public int UnreadNewsCount
		{
			get { return unreadNewsCount; }
			set { Set(ref unreadNewsCount, value); }
		}

		public int UnreadMessageCount
		{
			get { return unreadMessageCount; }
			set { Set(ref unreadMessageCount, value); }
		}

		public int UnreadNotificationsCount
		{
			get { return unreadNotificationsCount; }
			set { Set(ref unreadNotificationsCount, value); }
		}

		private bool isUserLoggedIn = false;

		private bool isUserAdult = true;

		private int unreadNewsCount = 0;

		private int unreadNotificationsCount = 0;

		private int unreadMessageCount = 0;
	}
}