using System.Collections.ObjectModel;
using Proxer.Me.Support.Api.Data.Notification;

namespace Proxer.Me.UWP.Models
{
	public class NewsModel : ProxerModel
	{
		private ObservableCollection<News> newsCollection;
		private int currentPage = 0;

		public ObservableCollection<News> NewsCollection
		{
			get { return newsCollection; }
			set { Set(ref newsCollection, value); }
		}

		public int CurrentPage
		{
			get { return currentPage; }
			set { Set(ref currentPage, value); }
		}

		public News SelectedNews
		{
			get { return selectedNews; }
			set { Set(ref selectedNews, value); }
		}

		public bool HasMoreItems
		{
			get { return hasMoreItems; }
			set { Set(ref hasMoreItems, value); }
		}

		private News selectedNews;

		private bool hasMoreItems = false;
	}
}