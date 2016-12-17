using System.Collections.Generic;
using System.Threading.Tasks;
using Proxer.Me.Api;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Media;
using Proxer.Me.UWP.Core;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class ProxerViewModel<T> : ViewModelBase where T : ProxerModel
	{
		#region Public Properties

		public T Model { get; }

		#endregion Public Properties

		public ProxerViewModel(T model)
		{
			Model = model;
		}

		private bool HandleCaptcha(ResponseData data)
		{
			if (ErrorHandler.IsIPBlocked(data))
			{
				NavigationService.Navigate(typeof(WebPage), ErrorHandler.CaptchaURL);
				return true;
			}
			return false;
		}

		public void HandleException(ResponseData data)
		{
			Busy.SetBusy(false);
			if (!HandleCaptcha(data))
			{
				Info.SetInfo(true, ErrorHandler.GetErrorMessage(data));
				if (data.Code == (int)Codes.ExpiredToken)
				{
					Model.ShellModel.GlobalToken = null;
					Model.ShellModel.GlobalUsername = null;
					Model.ShellModel.GlobalAvatar = null;
					Model.ShellModel.IsUserAdult = false;
					Model.ShellModel.IsUserLoggedIn = false;
					ProxerClient.Client.DefaultRequestHeaders.Remove("proxer-api-token");
					Windows.Storage.ApplicationData.Current.LocalSettings.Values.Remove("Token");
				}
			}
		}

		private async Task GetRandomHeader()
		{
			if (!Model.SettingsModel.ShowHeader)
				return;
			IDictionary<string, string> postParas = new Dictionary<string, string>();
			ResponseData<RandomHeader> header = await MediaAPI.GetRandomHeader(postParas);
			if (!header.Error)
			{
				Model.Header = header.Data;
			}
		}

		private async Task GetPushCount()
		{
			if (Model.ShellModel.IsUserLoggedIn)
			{
				ResponseData<int[]> data = await NotificationsAPI.GetCount();
				if (!data.Error)
				{
					Model.ShellModel.UnreadNewsCount = data.Data[4];
					Model.ShellModel.UnreadNotificationsCount = data.Data[5];
					Model.ShellModel.UnreadMessageCount = data.Data[1] + data.Data[2];
				}
				//await NotificationsAPI.SetDelete(new Dictionary<string, string>());
			}
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			await GetPushCount();
			await GetRandomHeader();
			await base.OnNavigatedToAsync(parameter, mode, state);
		}
	}
}