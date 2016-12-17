using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Controls.Collections;
using Proxer.Me.Support.Api.Data.Notification;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class NewsViewModel : ProxerViewModel<NewsModel>
	{
		public ICommand LoadNextPage { get; private set; }

		public ICommand OpenNews { get; private set; }

		public NewsViewModel() : base(new NewsModel())
		{
			LoadNextPage = new DelegateCommand<object>(ExecuteLoadNextPage);
			OpenNews = new DelegateCommand(ExecuteOpenNews);
			Model.NewsCollection = new AutoLoadCollection<News>(LoadNextPage);
		}

		private async void ExecuteOpenNews()
		{
			if (Model.SelectedNews != null)
			{
				if (Model.SettingsModel.OpenNewsInBrowser)
				{
					string uriToLaunch = $"http://proxer.me/forum/{Model.SelectedNews.CatID}/{Model.SelectedNews.Thread}";
					await Windows.System.Launcher.LaunchUriAsync(new Uri(uriToLaunch));
				}
				else
				{
					await NavigationService.NavigateAsync(typeof(WebPage), $"http://proxer.me/forum/{Model.SelectedNews.CatID}/{Model.SelectedNews.Thread}");
				}
			}
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			Model.SelectedNews = null;
			if (Model.NewsCollection.Count == 0)
			{
				LoadNextPage.Execute(null);
			}
			await base.OnNavigatedToAsync(parameter, mode, state);
		}

		private async void ExecuteLoadNextPage(object parameter)
		{
			Busy.SetBusy(true, "News werden abgerufen");
			int count = 50;
			IDictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("p", Model.CurrentPage.ToString());
			postParas.Add("limit", count.ToString());
			var news = await NotificationsAPI.GetNews(postParas);
			if (!news.Error)
			{
				if (news.Data.Count == count)
				{
					Model.HasMoreItems = true;
					Model.CurrentPage += 1;
				}
				else
					Model.HasMoreItems = false;
				foreach (var item in news.Data)
				{
					Model.NewsCollection.Add(item);
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(news);
			}
		}
	}
}