using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proxer.Me.Api;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.User;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class LoginViewModel : ProxerViewModel<LoginModel>
	{
		private WebView webview;

		public DelegateCommand LogInOut { get; private set; }

		public LoginViewModel() : base(new LoginModel())
		{
			webview = new WebView();
			webview.Navigate(new Uri("https://proxer.me/component/users/"));
			LogInOut = new DelegateCommand(ExecuteLogInOut, CanExecuteLogInOut);
			Model.PropertyChanged += Model_PropertyChanged;
		}

		private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Model.Password) | e.PropertyName == nameof(Model.ShellModel.GlobalUsername))
			{
				LogInOut.RaiseCanExecuteChanged();
			}
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			Model.JapaneseInfo = "いってらっしゃい";
			if (!string.IsNullOrWhiteSpace(Model.ShellModel.GlobalToken) && !Model.ShellModel.IsUserLoggedIn)
			{
				await loginLogout(true);
			}
			await base.OnNavigatedToAsync(parameter, mode, state);
		}

		private bool CanExecuteLogInOut()
		{
			if (Model.ShellModel.IsUserLoggedIn)
				return true;
			return !string.IsNullOrWhiteSpace(Model.ShellModel.GlobalUsername) & !string.IsNullOrWhiteSpace(Model.Password);
		}

		private async void ExecuteLogInOut()
		{
			await loginLogout();
		}

		private async Task loginLogout(bool autoLogin = false)
		{
			if (autoLogin)
			{
				Model.ExecuteAutoLogin = true;
				Busy.SetBusy(true, "User wird eingeloggt");
				ResponseData<UserInfo> userInfo = await UserAPI.GetUserInfo();
				if (!userInfo.Error)
				{
					Model.ShellModel.GlobalUsername = userInfo.Data.Username;
					Model.ShellModel.GlobalAvatar = userInfo.Data.Avatar;
					Model.ShellModel.IsUserLoggedIn = true;
					await BootStrapper.Current.NavigationService.NavigateAsync(typeof(UserControlPanelPage));
					Busy.SetBusy(false);
				}
				else
				{
					HandleException(userInfo);
				}
				Model.ExecuteAutoLogin = false;
			}
			else
			{
				if (!Model.ShellModel.IsUserLoggedIn)
				{
					Busy.SetBusy(true, "User wird eingeloggt");
					Dictionary<string, string> parameters = new Dictionary<string, string>();
					parameters.Add("username", Model.ShellModel.GlobalUsername);
					parameters.Add("password", Model.Password);
					ResponseData<Login> user = await UserAPI.LoginUser(parameters);
					if (!user.Error)
					{
						ProxerClient.Client.DefaultRequestHeaders.Add("proxer-api-token", user.Data.Token);
						Windows.Storage.ApplicationData.Current.LocalSettings.Values["Token"] = user.Data.Token;
						//await loginToWebView();
						Model.ShellModel.GlobalToken = user.Data.Token;
						Model.ShellModel.GlobalAvatar = user.Data.Avatar;
						ResponseData<UserInfo> userInfo = await UserAPI.GetUserInfo();
						if (!user.Error)
						{
							Model.ShellModel.GlobalUsername = userInfo.Data.Username;
						}
						Model.ShellModel.IsUserLoggedIn = true;
						await BootStrapper.Current.NavigationService.NavigateAsync(typeof(UserControlPanelPage));
						Busy.SetBusy(false);
					}
					else
					{
						Model.ShellModel.IsUserLoggedIn = false;
						HandleException(user);
					}
				}
				else
				{
					Busy.SetBusy(true, "User wird ausgeloggt");
					ResponseData user = await UserAPI.LogoutUser();
					Model.ShellModel.IsUserLoggedIn = false;
					Model.ShellModel.UnreadNewsCount = 0;
					Model.ShellModel.UnreadNotificationsCount = 0;
					Model.ShellModel.GlobalToken = null;
					Model.JapaneseInfo = "さようなら";
					//await logoutOfWebView();
					ProxerClient.Client.DefaultRequestHeaders.Remove("proxer-api-token");
					Windows.Storage.ApplicationData.Current.LocalSettings.Values.Remove("Token");
					Busy.SetBusy(false);
					if (user.Error)
						HandleException(user);
				}
			}
			Model.Password = "";
		}

		private async Task logoutOfWebView()
		{
			await webview.InvokeScriptAsync("eval", new string[]
			{
				"$('.form-validate').submit()"
			});
			await Task.Delay(1000);
			webview.Navigate(new Uri("https://proxer.me/component/users/"));
		}

		private async Task loginToWebView()
		{
			await webview.InvokeScriptAsync("eval", new string[]
			{
				$"$('#username').val('{Model.ShellModel.GlobalUsername}');$('#password').val('{Model.Password}');$('.form-validate').submit()"
			});
			await Task.Delay(1000);
			webview.Navigate(new Uri("https://proxer.me/component/users/"));
		}
	}
}