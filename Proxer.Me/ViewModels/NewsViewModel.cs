using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxAPI;
using Proxer.Me.Records;

namespace Proxer.Me.ViewModels
{
	public class NewsViewModel : ViewModel<NewsModel>
	{
		static NewsViewModel()
		{
			Instance = new NewsViewModel();
		}

		public static NewsViewModel Instance { get; private set; }

		public DelegateCommand RefreshNews { get; private set; }

		public DelegateCommand NextPage { get; private set; }

		public DelegateCommand PreviousPage { get; private set; }

		public NewsViewModel() : base(new NewsModel())
		{
			RefreshNews = new DelegateCommand(ExecuteRefreshNews, CanExecuteRefreshNews);
			NextPage = new DelegateCommand(ExecuteNextPage, CanExecuteNextPage);
			PreviousPage = new DelegateCommand(ExecutePreviousPage, CanExecutePreviousPage);
			RefreshNews.Execute(null);
		}

		private bool CanExecutePreviousPage(object obj)
		{
			return !Model.IsWorking && Model.CurrentPage > 0; 
		}

		private async void ExecutePreviousPage(object obj)
		{
			Model.IsWorking = true;
			Model.CurrentPage -= 1;
			RefreshNews.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
			var news = await NotificationsAPI.GetNews(Model.CurrentPage);
			Model.News.Clear();
			if (!news.Error)
			{
				foreach (var item in news.Data)
				{
					Model.News.Add(new NewsRecord(item));
				}
			}
			else
			{
				ErrorHandler.ShowError(news.Code);
			}
			Model.IsWorking = false;
			RefreshNews.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
		}

		private bool CanExecuteNextPage(object obj)
		{
			return !Model.IsWorking && Model.HasNextPage;
		}

		private async void ExecuteNextPage(object obj)
		{
			Model.IsWorking = true;
			Model.CurrentPage += 1;
			RefreshNews.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
			var news = await NotificationsAPI.GetNews(Model.CurrentPage);
			Model.News.Clear();
			if (!news.Error)
			{
				foreach (var item in news.Data)
				{
					Model.News.Add(new NewsRecord(item));
				}
			}
			else
			{
				ErrorHandler.ShowError(news.Code);
			}
			Model.IsWorking = false;
			RefreshNews.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
		}

		private bool CanExecuteRefreshNews(object obj)
		{
			return !Model.IsWorking;
		}

		private async void ExecuteRefreshNews(object obj)
		{
			Model.IsWorking = true;
			Model.HasNextPage = false;
			RefreshNews.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
			var news = await NotificationsAPI.GetNews(Model.CurrentPage, 16);
			Model.News.Clear();
			if (!news.Error)
			{
				if (news.Data.Count == 16)
					Model.HasNextPage = true;
				foreach (var item in news.Data)
				{
					if (news.Data.Count == 16 && news.Data.IndexOf(item) == 15)
					{
						continue;
					}
					Model.News.Add(new NewsRecord(item));
				}
			}
			else
			{
				ErrorHandler.ShowError(news.Code);
			}
			Model.IsWorking = false;
			RefreshNews.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();

		}

		public override void RefreshPageContent()
		{
			base.RefreshPageContent();
			Model.CurrentPage = 0;
			RefreshNews.Execute(null);
		}
	}
}
