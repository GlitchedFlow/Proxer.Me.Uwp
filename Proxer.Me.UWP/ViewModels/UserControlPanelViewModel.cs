using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.UCP;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.UWP.ViewModels
{
	public class UserControlPanelViewModel : ProxerViewModel<UserControlPanelModel>
	{
		public ICommand LoadAnimePage { get; private set; }

		public ICommand LoadMangaPage { get; private set; }

		public ICommand LoadReminderPage { get; private set; }

		public ICommand LoadHistoryPage { get; private set; }

		public ICommand OpenEntry { get; private set; }

		public ICommand OpenContent { get; private set; }

		public ICommand DeleteVote { get; private set; }

		public ICommand DeleteTopTen { get; private set; }

		public ICommand DeleteReminder { get; private set; }

		public ICommand OpenWebReaderPage { get; private set; }

		private bool animeReminderSelected = false;
		private bool animeTopTenSelected = false;

		public UserControlPanelViewModel() : base(new UserControlPanelModel())
		{
			Model.AnimeCollection = new ObservableCollection<List>();
			Model.MangaCollection = new ObservableCollection<List>();
			Model.ReminderCollection = new ObservableCollection<Reminder>();
			Model.TopTenCollection = new ObservableCollection<TopTen>();
			Model.HistoryCollection = new ObservableCollection<History>();
			Model.VoteCollection = new ObservableCollection<Vote>();
			Model.PropertyChanged += Model_PropertyChanged;
			LoadAnimePage = new DelegateCommand(ExecuteLoadAnimePage);
			LoadMangaPage = new DelegateCommand(ExecuteLoadMangaPage);
			LoadReminderPage = new DelegateCommand(ExecuteLoadReminderPage);
			LoadHistoryPage = new DelegateCommand(ExecuteLoadHistoryPage);
			OpenEntry = new DelegateCommand(ExecuteOpenEntry);
			DeleteVote = new DelegateCommand<int>(ExecuteDeleteVote);
			DeleteTopTen = new DelegateCommand<int>(ExecuteDeleteTopTen);
			DeleteReminder = new DelegateCommand<int>(ExecuteDeleteReminder);
			OpenWebReaderPage = new DelegateCommand<ItemClickEventArgs>(ExecuteOpenWebReaderPage);
		}

		private async void ExecuteOpenWebReaderPage(ItemClickEventArgs args)
		{
			Reminder reminder = args.ClickedItem as Reminder;
			//EntryURLWrapper parameter = new EntryURLWrapper(null, );
			await Dispatcher.DispatchAsync(async () =>
			{
				if (Model.ShellModel.UseWebReader)
				{
					await BootStrapper.Current.NavigationService.NavigateAsync(typeof(MangaReaderPage), $"https://proxer.me/read/{reminder.EID}/{reminder.Number}/{reminder.Language}/1");
				}
				else
				{
				}
			}, 50);
		}

		public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
		{
			Model.AnimeCollection.Clear();
			Model.MangaCollection.Clear();
			Model.ReminderCollection.Clear();
			Model.RaisePropertyChanged(nameof(Model.ReminderCollection));
			Model.TopTenCollection.Clear();
			Model.RaisePropertyChanged(nameof(Model.TopTenCollection));
			Model.HistoryCollection.Clear();
			Model.VoteCollection.Clear();
			Model.CurrentAnimePage = 0;
			Model.CurrentHistoryPage = 0;
			Model.CurrentMangaPage = 0;
			Model.CurrentReminderPage = 0;
			Model.SelectedContent = 0;
			return base.OnNavigatedFromAsync(pageState, suspending);
		}

		private async void ExecuteDeleteReminder(int rid)
		{
			Busy.SetBusy(true, "Lesezeichen wird entfernt...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", rid.ToString());
			ResponseData result = await UCPAPI.SetDeleteReminder(postParas);
			if (!result.Error)
			{
				Reminder target = Model.ReminderCollection.Where(x => x.ID == rid).FirstOrDefault();
				if (target != null)
				{
					Model.ReminderCollection.Remove(target);
					Model.RaisePropertyChanged(nameof(Model.ReminderCollection));
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async void ExecuteDeleteTopTen(int tid)
		{
			Busy.SetBusy(true, "Top Ten Eintrag wird entfernt...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", tid.ToString());
			ResponseData result = await UCPAPI.SetDeleteFavorite(postParas);
			if (!result.Error)
			{
				TopTen target = Model.TopTenCollection.Where(x => x.FID == tid).FirstOrDefault();
				if (target != null)
				{
					Model.TopTenCollection.Remove(target);
					Model.RaisePropertyChanged(nameof(Model.TopTenCollection));
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async void ExecuteDeleteVote(int vid)
		{
			Busy.SetBusy(true, "Vote wird entfernt...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", vid.ToString());
			ResponseData result = await UCPAPI.SetDeleteVote(postParas);
			if (!result.Error)
			{
				Vote targetVote = Model.VoteCollection.Where(x => x.ID == vid).FirstOrDefault();
				if (targetVote != null)
					Model.VoteCollection.Remove(targetVote);
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async void ExecuteOpenEntry()
		{
			await Task.Delay(50);
			switch (Model.SelectedContent)
			{
				case 1:
					await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedAnime.ID);
					break;

				case 2:
					await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedManga.ID);
					break;

				case 3:
					if (animeReminderSelected)
						await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedAnimeReminder.EID);
					else
						await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedMangaReminder.EID);
					break;

				case 4:
					if (animeTopTenSelected)
						await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedAnimeTopTen.EID);
					else
						await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedMangaTopTen.EID);
					break;

				case 5:
					await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedHistory.ID);
					break;

				default:
					break;
			}
		}

		private async Task getVotes()
		{
			Busy.SetBusy(true, "Votes werden geladen...");
			ResponseData<List<Vote>> result = await UCPAPI.GetVotes();
			if (!result.Error)
			{
				foreach (var item in result.Data)
				{
					Model.VoteCollection.Add(item);
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async void ExecuteLoadHistoryPage()
		{
			Busy.SetBusy(true, "Chronik wird geladen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			int getItemsCount = 50;
			postParas.Add("p", Model.CurrentHistoryPage.ToString());
			postParas.Add("limit", getItemsCount.ToString());
			ResponseData<List<History>> result = await UCPAPI.GetHistory(postParas);
			if (!result.Error)
			{
				if (result.Data.Count == getItemsCount)
				{
					Model.HasMoreHistory = true;
					Model.CurrentHistoryPage++;
				}
				else
				{
					Model.HasMoreHistory = false;
				}
				foreach (var item in result.Data)
				{
					Model.HistoryCollection.Add(item);
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async void ExecuteLoadReminderPage()
		{
			Busy.SetBusy(true, "Lesezeichen werden geladen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			int getItemsCount = 200;
			postParas.Add("p", Model.CurrentReminderPage.ToString());
			postParas.Add("limit", getItemsCount.ToString());
			ResponseData<List<Reminder>> result = await UCPAPI.GetReminder(postParas);
			if (!result.Error)
			{
				if (result.Data.Count == getItemsCount)
				{
					Model.HasMoreReminder = true;
					Model.CurrentReminderPage++;
				}
				else
				{
					Model.HasMoreReminder = false;
				}
				foreach (var item in result.Data)
				{
					Model.ReminderCollection.Add(item);
				}
				Model.RaisePropertyChanged(nameof(Model.ReminderCollection));
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async void ExecuteLoadMangaPage()
		{
			await getAnimeManga(false);
		}

		private async void ExecuteLoadAnimePage()
		{
			await getAnimeManga(true);
		}

		private async void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Model.SelectedContent))
			{
				if (Model.SelectedContent == 1)
				{
					if (Model.AnimeCollection.Count == 0)
						LoadAnimePage.Execute(null);
				}
				else if (Model.SelectedContent == 2)
				{
					if (Model.MangaCollection.Count == 0)
						LoadMangaPage.Execute(null);
				}
				else if (Model.SelectedContent == 3)
				{
					if (Model.ReminderCollection.Count == 0)
						LoadReminderPage.Execute(null);
				}
				else if (Model.SelectedContent == 4)
				{
					if (Model.TopTenCollection.Count == 0)
						await getTopTen();
				}
				else if (Model.SelectedContent == 5)
				{
					if (Model.HistoryCollection.Count == 0)
						LoadHistoryPage.Execute(null);
				}
				else if (Model.SelectedContent == 6)
				{
					if (Model.VoteCollection.Count == 0)
						await getVotes();
				}
			}
			else if (e.PropertyName == nameof(Model.SelectedAnimeReminder))
				animeReminderSelected = true;
			else if (e.PropertyName == nameof(Model.SelectedMangaReminder))
				animeReminderSelected = false;
			else if (e.PropertyName == nameof(Model.SelectedAnimeTopTen))
				animeTopTenSelected = true;
			else if (e.PropertyName == nameof(Model.SelectedMangaTopTen))
				animeTopTenSelected = false;
		}

		private async Task getTopTen()
		{
			Busy.SetBusy(true, "Top 10 werden geladen...");
			ResponseData<List<TopTen>> result = await UCPAPI.GetTopTen();
			if (!result.Error)
			{
				foreach (var topTen in result.Data)
				{
					Model.TopTenCollection.Add(topTen);
				}
				Model.RaisePropertyChanged(nameof(Model.TopTenCollection));
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async Task getAnimeManga(bool isAnime)
		{
			Busy.SetBusy(true, $"{(isAnime ? "Anime" : "Manga")} werden geladen");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			int getItemsCount = 2000;
			if (!isAnime)
				postParas.Add("kat", "manga");
			postParas.Add("limit", getItemsCount.ToString());
			ResponseData<List<List>> result = await UCPAPI.GetList(postParas);
			if (!result.Error)
			{
				if (result.Data.Count == getItemsCount)
				{
					if (isAnime)
					{
						Model.HasMoreAnime = true;
						Model.CurrentAnimePage++;
					}
					else
					{
						Model.HasMoreManga = true;
						Model.CurrentMangaPage++;
					}
				}
				else
				{
					if (isAnime)
						Model.HasMoreAnime = false;
					else
						Model.HasMoreManga = false;
				}
				foreach (var entry in result.Data)
				{
					if (isAnime)
						Model.AnimeCollection.Add(entry);
					else
						Model.MangaCollection.Add(entry);
				}
				if (isAnime)
				{
					Model.RaisePropertyChanged(nameof(Model.AnimeCollection));
					foreach (var entry in Model.AnimeCollection)
					{
						entry.RaisePropertyChanged(nameof(entry.Count));
						entry.RaisePropertyChanged(nameof(entry.Episode));
						//Debug.WriteLine(entry.Name + " " + entry.Episode + "/" + entry.Count);
					}
				}
				else
				{
					Model.RaisePropertyChanged(nameof(Model.MangaCollection));
					foreach (var entry in Model.MangaCollection)
					{
						entry.RaisePropertyChanged(nameof(entry.Count));
						entry.RaisePropertyChanged(nameof(entry.Episode));
						//Debug.WriteLine(entry.Name + " " + entry.Episode + "/" + entry.Count);
					}
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}
	}
}