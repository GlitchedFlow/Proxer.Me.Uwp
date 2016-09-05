using System;
using System.Linq;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Interfaces;
using Proxer.Me.Models;
using Proxer.Me.ProxAPI;
using Proxer.Me.ProxSupport;
using Proxer.Me.Views;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.ViewModels
{
	public class ViewModel<T> : Notifier, INavigatedTo where T : Model
	{
		public T Model { get; }

		public DelegateCommand RefreshHeader { get; private set; }

		public DelegateCommand Home { get; private set; }

		public DelegateCommand AnimeOverview { get; private set; }

		public DelegateCommand MangaOverview { get; private set; }

		public DelegateCommand News { get; private set; }

		public DelegateCommand Search { get; private set; }

		public DelegateCommand QuickSearch { get; private set; }

		public DelegateCommand UserControlPanel { get; private set; }

		public DelegateCommand Login { get; private set; }

		public DelegateCommand Logout { get; private set; }

		public DelegateCommand Settings { get; private set; }

		public DelegateCommand Messenger { get; private set; }

		public DelegateCommand Statistics { get; private set; }

		protected bool _hasShowedError;

		public DelegateCommand Profile
		{
			get { return ProfileViewModel.Instance.OpenProfile; }
		}

		public ViewModel(T model)
		{
			Model = model;
			Home = new DelegateCommand(ExecuteHome);
			AnimeOverview = new DelegateCommand(ExecuteAnimeOverview);
			MangaOverview = new DelegateCommand(ExecuteMangaOverview);
			UserControlPanel = new DelegateCommand(ExecuteUserControlPanel);
			RefreshHeader = new DelegateCommand(ExecuteRefreshHeader);
			Login = new DelegateCommand(ExecuteLogin, CanExecuteLogin);
			Logout = new DelegateCommand(ExecuteLogout);
			Settings = new DelegateCommand(ExecuteSettings);
			Messenger = new DelegateCommand(ExecuteMessenger);
			Statistics = new DelegateCommand(ExecuteStatistics);
			News = new DelegateCommand(ExecuteNews);
			Model.UserDataChanged += Model_UserDataChanged;
		}

		private void ExecuteNews(object obj)
		{
			var frame = Window.Current.Content as Frame;
			frame.Navigate(typeof(NewsPage), null);
		}

		private void ExecuteStatistics(object obj)
		{
		}

		private void ExecuteMessenger(object obj)
		{
			var frame = Window.Current.Content as Frame;
			frame.Navigate(typeof(MessengerPage), null);
		}

		private void ExecuteSettings(object obj)
		{
			var frame = Window.Current.Content as Frame;
			frame.Navigate(typeof(SettingsPage), null);
		}

		private void ExecuteMangaOverview(object obj)
		{
			var frame = Window.Current.Content as Frame;
			frame.Navigate(typeof(MangaOverviewPage), null);
		}

		private async void ExecuteLogout(object obj)
		{
			var logout = await UserAPI.LogoutUser();
			Models.Model.LoggedInUser = null;
			LoginViewModel.Instance.Model.UserLoggedIn = false;
			LoginViewModel.Instance.Model.ExecuteAutoLogin = false;
			LoginViewModel.Instance.Model.JapaneseInfo = "さようなら";
			ProxerClient.Instance.Client.DefaultRequestHeaders.Remove("proxer-api-token");
			var frame = Window.Current.Content as Frame;
			frame.Navigate(typeof(LoginPage), null);
		}

		private void Model_UserDataChanged(object sender, EventArgs e)
		{
			Login.RaiseCanExecuteChanged();
		}

		private bool CanExecuteLogin(object obj)
		{
			return !string.IsNullOrWhiteSpace(Model.Username) && !string.IsNullOrWhiteSpace(Model.Password);
		}

		private async void ExecuteLogin(object obj)
		{
			var login = await UserAPI.LoginUser(Model.Username, Model.Password);

			if (login.Error)
			{
				if (login.Code == (int)Codes.DiffrentUserAlreadyLoggedIn)
				{
					var userinfo = await UserAPI.GetUserInfo();
					Models.Model.LoggedInUser = new ProxData.User.Data.LoginData() { Avatar = userinfo.Data.Avatar, Token = Model.Settings.UserToken, UID = userinfo.Data.UID };
					if (!userinfo.Error)
					{
						Model.Username = userinfo.Data.Username;
						Model.UID = userinfo.Data.UID;
						Model.Password = "";
					}
					else
					{
						ErrorHandler.ShowError(userinfo.Code);
						Models.Model.LoggedInUser = null;
					}
					Home.Execute(null);
				}
				else
				{
					ErrorHandler.ShowError(login.Code);
					Models.Model.LoggedInUser = null;
					if (login.Code == (int)Codes.ExpiredToken)
						ProxerClient.Instance.Client.DefaultRequestHeaders.Remove("proxer-api-token");
				}
			}
			else
			{
				Models.Model.LoggedInUser = login.Data;
				Model.Settings.UserToken = login.Data.Token;
				var userinfo = await UserAPI.GetUserInfo(login.Data.UID);
				if (!userinfo.Error)
				{
					Model.Username = userinfo.Data.Username;
					Model.UID = userinfo.Data.UID;
					Home.Execute(null);
					Model.Password = "";
				}
				else
				{
					ErrorHandler.ShowError(userinfo.Code);
				}
			}
		}

		private void ExecuteAnimeOverview(object obj)
		{
			var frame = Window.Current.Content as Frame;
			frame.Navigate(typeof(AnimeOverviewPage), null);
		}

		private void ExecuteUserControlPanel(object obj)
		{
			if (Models.Model.LoggedInUser == null)
			{
				//var frame = Window.Current.Content as Frame;
				//frame.Navigate(typeof(LoginPage), null);
			}
			else
			{
				var frame = Window.Current.Content as Frame;
				frame.Navigate(typeof(UserControlPage), null);
			}
		}

		private void ExecuteHome(object obj)
		{
			var frame = Window.Current.Content as Frame;
			switch (Model.Settings.Home)
			{
				case HomePage.News:
					frame.Navigate(typeof(NewsPage), null);
					break;

				case HomePage.AnimeOverview:
					frame.Navigate(typeof(AnimeOverviewPage), null);
					break;

				case HomePage.MangaOverview:
					frame.Navigate(typeof(MangaOverviewPage), null);
					break;

				case HomePage.UCP:
					frame.Navigate(typeof(UserControlPage), null);
					break;
			}
		}

		private async void ExecuteRefreshHeader(object obj)
		{
			if (Model.Settings.ShowHeader)
			{
				var header = await MediaAPI.GetRandomHeader();
				if (!header.Error)
				{
					Model.Header = $"http://cdn.proxer.me/gallery/originals/{header.Data.CatPath}/{header.Data.ImgFileName}";
				}
				else
				{
					ErrorHandler.ShowError(header.Code);
				}
			}
		}

		public virtual void RefreshPageContent()
		{
			RefreshHeader.Execute(null);
		}

		public void ModelNotifyPropertyChanged(string Property)
		{
			Model.NotifyPropertyChanged(Property);
		}

		public bool Reload(object param)
		{
			var frame = Window.Current.Content as Frame;
			Type type = frame.CurrentSourcePageType;
			try { return frame.Navigate(type, param); }
			finally { frame.BackStack.Remove(frame.BackStack.Last()); }
		}
	}
}