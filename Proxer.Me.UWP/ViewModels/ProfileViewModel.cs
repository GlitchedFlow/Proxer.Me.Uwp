using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class ProfileViewModel : PaneViewModel<ProfileModel>
	{
		public ICommand OpenEntry { get; private set; }

		public ICommand LoadAnimePage { get; private set; }

		public ICommand LoadMangaPage { get; private set; }

		public ICommand LoadCommentPage { get; private set; }

		public ICommand OpenEntryFromComment { get; private set; }

		private int uid;
		private bool animeTopTenSelected = false;

		public ProfileViewModel() : base(new ProfileModel())
		{
			Model.AnimeCollection = new ObservableCollection<List>();
			Model.MangaCollection = new ObservableCollection<List>();
			Model.TopTenCollection = new ObservableCollection<TopTen>();
			Model.CommentCollection = new ObservableCollection<Comment>();
			LoadAnimePage = new DelegateCommand(ExecuteLoadAnimePage);
			LoadMangaPage = new DelegateCommand(ExecuteLoadMangaPage);
			LoadCommentPage = new DelegateCommand(ExecuteLoadCommentPage);
			OpenEntry = new DelegateCommand(ExecuteOpenEntry);
			OpenEntryFromComment = new DelegateCommand<int>(ExecuteOpenEntryFromComment);
			Model.PropertyChanged += Model_PropertyChanged;
		}

		private async void ExecuteOpenEntryFromComment(int eid)
		{
			await NavigationService.NavigateAsync(typeof(EntryPage), eid);
		}

		private async void ExecuteLoadCommentPage()
		{
			Busy.SetBusy(true, "Kommentare werden geladen");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			int getItemsCount = 20;
			postParas.Add("uid", uid.ToString());
			postParas.Add("p", Model.CurrentCommentPage.ToString());
			postParas.Add("limit", getItemsCount.ToString());
			postParas.Add("length", "10");
			ResponseData<List<Comment>> result = await UserAPI.GetComments(postParas);
			if (!result.Error)
			{
				if (result.Data.Count == getItemsCount)
				{
					Model.HasMoreComments = true;
					Model.CurrentCommentPage++;
				}
				else
				{
					Model.HasMoreComments = false;
				}
				foreach (var comment in result.Data)
				{
					Model.CommentCollection.Add(comment);
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(result);
			}
		}

		private async void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Model.SelectedContent))
			{
				if (Model.SelectedContent == 0)
				{
					if (Model.TopTenCollection.Count == 0)
						await getTopTen();
				}
				else if (Model.SelectedContent == 1)
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
					if (Model.CommentCollection.Count == 0)
						LoadCommentPage.Execute(null);
				}
			}
			else if (e.PropertyName == nameof(Model.SelectedAnimeTopTen))
				animeTopTenSelected = true;
			else if (e.PropertyName == nameof(Model.SelectedMangaTopTen))
				animeTopTenSelected = false;
		}

		private async Task getTopTen()
		{
			Busy.SetBusy(true, "Top 10 werden geladen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("uid", uid.ToString());
			postParas.Add("kat", "anime");
			ResponseData<List<TopTen>> result = await UserAPI.GetTopTen(postParas);
			if (!result.Error)
			{
				foreach (var topTen in result.Data)
				{
					Model.TopTenCollection.Add(topTen);
				}
				postParas["kat"] = "manga";
				result = await UserAPI.GetTopTen(postParas);
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
				case 0:
					if (animeTopTenSelected)
						await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedAnimeTopTen.EID);
					else
						await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedMangaTopTen.EID);
					break;

				case 1:
					await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedAnime.ID);
					break;

				case 2:
					await NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedManga.ID);
					break;

				default:
					break;
			}
		}

		public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
		{
			Model.AnimeCollection.Clear();
			Model.CurrentAnimePage = 0;
			Model.MangaCollection.Clear();
			Model.CurrentMangaPage = 0;
			Model.SelectedContent = 0;
			Model.TopTenCollection.Clear();
			Model.CommentCollection.Clear();
			Model.CurrentCommentPage = 0;

			return base.OnNavigatedFromAsync(pageState, suspending);
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			if (parameter == null)
				BootStrapper.Current.NavigationService.GoBack();
			await getUser((int)parameter);
			await getTopTen();
			await base.OnNavigatedToAsync(parameter, mode, state);
		}

		private async Task getUser(int id)
		{
			Busy.SetBusy(true, "User wird abgerufen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("uid", id.ToString());
			ResponseData<UserInfo> result = await UserAPI.GetUserInfo(postParas);
			if (!result.Error)
			{
				Model.Username = result.Data.Username;
				Dictionary<string, int> points = new Dictionary<string, int>();
				points.Add("Anime", result.Data.PointsAnime);
				points.Add("Manga", result.Data.PointsManga);
				points.Add("Uploads", result.Data.PointsUploads);
				points.Add("Forum", result.Data.PointsForum);
				points.Add("Info", result.Data.PointsInfo);
				points.Add("Zsp", result.Data.PointsMisc);
				Model.Points = points;
				Model.RaisePropertyChanged(nameof(Model.PointsTotal));
				Model.Status = result.Data.Status;
				Model.Avatar = result.Data.Avatar;
				uid = result.Data.UID;
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

		private async Task getAnimeManga(bool isAnime)
		{
			Busy.SetBusy(true, $"{(isAnime ? "Anime" : "Manga")} werden geladen");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			int getItemsCount = 2000;
			if (!isAnime)
				postParas.Add("kat", "manga");
			postParas.Add("uid", uid.ToString());
			postParas.Add("limit", getItemsCount.ToString());
			ResponseData<List<List>> result = await UserAPI.GetList(postParas);
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