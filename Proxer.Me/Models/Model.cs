using System;
using Proxer.Me.Core;
using Proxer.Me.ProxData.User.Data;
using Windows.UI.Xaml.Media.Animation;

namespace Proxer.Me.Models
{
	public class Model : Notifier
	{
		private string _header;
		private bool _isWorking;
		private string _searchText;
		private Settings _settings;

		public event EventHandler UserDataChanged;

		public static LoginData LoggedInUser { get; set; }

		public static string _Username { get; set; }

		public static string _Password { get; set; }

		public string Avatar
		{
			get
			{
				if (IsLoggedIn)
				{
					var avatar = LoggedInUser.Avatar;
					return $"https://cdn.proxer.me/avatar/{avatar}";
				}
				return "";
			}
		}

		public bool IsLoggedIn
		{
			get { return LoggedInUser != null; }
		}

		public string Header
		{
			get
			{
				if (Settings.ShowHeader)
					return _header;
				return "";
			}
			set
			{
				_header = value;
				NotifyPropertyChanged();
			}
		}

		public bool IsWorking
		{
			get { return _isWorking; }
			set
			{
				_isWorking = value;
				NotifyPropertyChanged();
			}
		}

		public string SearchText
		{
			get { return _searchText; }
			set
			{
				_searchText = value;
				NotifyPropertyChanged();
			}
		}

		public string Username
		{
			get { return _Username; }
			set
			{
				_Username = value;
				NotifyPropertyChanged();
				UserDataChanged?.Invoke(this, new EventArgs());
			}
		}

		public string Password
		{
			get { return _Password; }
			set
			{
				_Password = value;
				NotifyPropertyChanged();
				UserDataChanged?.Invoke(this, new EventArgs());
			}
		}

		public Settings Settings
		{
			get
			{
				if (_settings == null)
				{
					_settings = Settings.Instance;
				}
				return _settings;
			}
		}

		public bool IsProgressRatingActive
		{
			get { return Settings.RatingStyle == ProxSupport.RatingStyle.Progress | Settings.RatingStyle == ProxSupport.RatingStyle.StarsProgress; }
		}

		public bool IsStarRatingActive
		{
			get { return Settings.RatingStyle == ProxSupport.RatingStyle.Stars | Settings.RatingStyle == ProxSupport.RatingStyle.StarsProgress; }
		}

		public bool IsRecommandationRatingActive
		{
			get { return Settings.RatingStyle == ProxSupport.RatingStyle.Recommendation; }
		}

		public int UID { get; set; }
	}
}