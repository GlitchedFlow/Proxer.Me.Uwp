using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.Info;
using Proxer.Me.Support.Records;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class EntryViewModel : PaneViewModel<EntryModel>
	{
		public ICommand LoadContentPage { get; private set; }

		public ICommand LoadCommentPage { get; private set; }

		public ICommand LoadRelationPage { get; private set; }

		public ICommand OpenContent { get; private set; }

		public ICommand LoadEntry { get; private set; }

		public ICommand CacheEntry { get; private set; }

		public ICommand NoteEntry { get; private set; }

		public ICommand FavriotEntry { get; private set; }

		public ICommand FinishEntry { get; private set; }

		public ICommand OpenUser { get; private set; }

		public EntryViewModel() : base(new EntryModel())
		{
			Model.ContentCollection = new ObservableCollection<ContentWrapper>();
			Model.Comments = new ObservableCollection<Comment>();
			Model.Relations = new ObservableCollection<Relation>();
			LoadContentPage = new DelegateCommand<ContentWrapper>(ExecuteLoadContentPage);
			LoadCommentPage = new DelegateCommand(ExecuteLoadCommentPage);
			LoadRelationPage = new DelegateCommand(ExecuteLoadRelationPage);
			LoadEntry = new DelegateCommand(ExecuteLoadEntry);
			NoteEntry = new DelegateCommand(ExecuteNoteEntry, IsUserLoggedIn);
			FavriotEntry = new DelegateCommand(ExecuteFavriotEntry, IsUserLoggedIn);
			FinishEntry = new DelegateCommand(ExecuteFinishEntry, IsUserLoggedIn);
			CacheEntry = new DelegateCommand(ExecuteCacheEntry, IsUserLoggedIn);
			OpenUser = new DelegateCommand<int>(ExecuteOpenUser, IsUserLoggedIn);
			OpenContent = new DelegateCommand<Episode>(ExecuteOpenContent);
			Model.PropertyChanged += Model_PropertyChanged;
		}

		private async void ExecuteOpenContent(Episode content)
		{
			content.ID = Model.FullEntry.ID;
			if (Model.FullEntry.Category == "anime")
			{
				await BootStrapper.Current.NavigationService.NavigateAsync(typeof(AnimePlayerPage), content);
			}
			else
			{
				await BootStrapper.Current.NavigationService.NavigateAsync(typeof(MangaReaderPage), content);
			}
		}

		private async void ExecuteOpenUser(int uid)
		{
			await BootStrapper.Current.NavigationService.NavigateAsync(typeof(ProfilePage), uid);
		}

		private void ExecuteCacheEntry()
		{
			return;
		}

		private bool IsUserLoggedIn()
		{
			return Model.ShellModel.IsUserLoggedIn;
		}

		private bool IsUserLoggedIn(int uid)
		{
			return IsUserLoggedIn();
		}

		private async void ExecuteFinishEntry()
		{
			Busy.SetBusy(true, $"Eintrag wird auf \"Abgeschlossen\" gesetzt");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", Model.FullEntry.ID.ToString());
			postParas.Add("type", "finish");
			ResponseData result = await InfoAPI.SetInfo(postParas);
			Busy.SetBusy(false);
			if (result.Error)
				HandleException(result);
			else
				Info.SetInfo(true, "Eintrag auf \"Abgeschlossen\" gesetzt");
		}

		private async void ExecuteFavriotEntry()
		{
			Busy.SetBusy(true, $"Eintrag wird auf \"Favorit\" gesetzt");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", Model.FullEntry.ID.ToString());
			postParas.Add("type", "favor");
			ResponseData result = await InfoAPI.SetInfo(postParas);
			Busy.SetBusy(false);
			if (result.Error)
				HandleException(result);
			else
				Info.SetInfo(true, "Eintrag in TopTen eingetragen");
		}

		private async void ExecuteNoteEntry()
		{
			Busy.SetBusy(true, $"Eintrag wird auf \"Wird noch {(Model.FullEntry.Category == "anime" ? "geschaut" : "gelesen")}\" gesetzt");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", Model.FullEntry.ID.ToString());
			postParas.Add("type", "note");
			ResponseData result = await InfoAPI.SetInfo(postParas);
			Busy.SetBusy(false);
			if (result.Error)
				HandleException(result);
			else
				Info.SetInfo(true, $"Eintrag auf \"Wird noch {(Model.FullEntry.Category == "anime" ? "geschaut" : "gelesen")}\" gesetzt");
		}

		private async void ExecuteLoadEntry()
		{
			await Task.Delay(50);
			if (Model.SelectedRelation != null)
			{
				await BootStrapper.Current.NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedRelation.ID);
			}
		}

		private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Model.SelectedContent))
			{
				if (Model.SelectedContent == 1)
				{
					if (Model.Comments.Count == 0)
					{
						ExecuteLoadCommentPage();
					}
				}
				if (Model.SelectedContent == 2)
				{
					if (Model.Relations.Count == 0)
					{
						ExecuteLoadRelationPage();
					}
				}
			}
		}

		private async void ExecuteLoadRelationPage()
		{
			if (Model.RelationsLoaded)
				return;
			Busy.SetBusy(true, "Verbindungen werden geladen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", Model.FullEntry.ID.ToString());
			ResponseData<List<Relation>> relations = await InfoAPI.GetRelations(postParas);
			if (!relations.Error)
			{
				foreach (var item in relations.Data)
				{
					Model.Relations.Add(item);
				}
				Model.SelectedRelation = null;
				Model.RaisePropertyChanged(nameof(Model.Relations));
				Model.RelationsLoaded = true;
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(relations);
			}
		}

		private async void ExecuteLoadCommentPage()
		{
			if (!Model.HasMoreComments)
				return;
			Busy.SetBusy(true, "Kommentare werden geladen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			int getItemsCount = 25;
			postParas.Add("id", Model.FullEntry.ID.ToString());
			postParas.Add("p", Model.CurrentCommentPage.ToString());
			postParas.Add("limit", getItemsCount.ToString());
			ResponseData<List<Comment>> comments = await InfoAPI.GetComments(postParas);
			if (!comments.Error)
			{
				if (comments.Data.Count == getItemsCount)
				{
					Model.HasMoreComments = true;
					Model.CurrentCommentPage++;
				}
				else
				{
					Model.HasMoreComments = false;
				}
				foreach (var comment in comments.Data)
				{
					Model.Comments.Add(comment);
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(comments);
			}
		}

		private async void ExecuteLoadContentPage(ContentWrapper obj)
		{
			if (obj == null)
				return;

			if (obj.ContentLoaded)
				return;

			Busy.SetBusy(true, $"{Model.ContentTab} werden geladen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", Model.FullEntry.ID.ToString());
			postParas.Add("p", Model.ContentCollection.IndexOf(obj).ToString());
			ResponseData<ListInfo> result = await InfoAPI.GetListInfo(postParas);
			if (!result.Error)
			{
				obj.Content = result.Data.Episodes.GroupBy(x => x.Language);
				Model.State = result.Data.State;
				Busy.SetBusy(false);
				obj.ContentLoaded = true;
			}
			else
			{
				HandleException(result);
			}
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			if (parameter == null)
				BootStrapper.Current.NavigationService.GoBack();

			Model.SelectedContent = 0;
			Model.Comments.Clear();
			Model.CurrentCommentPage = 0;
			Model.HasMoreComments = true;
			Model.SelectedRelation = null;
			Model.Relations.Clear();
			Model.RelationsLoaded = false;
			Model.RaisePropertyChanged(nameof(Model.Relations));
			await getEntry(Convert.ToInt32(parameter));
			await base.OnNavigatedToAsync(parameter, mode, state);
		}

		private async Task getEntry(int id)
		{
			Busy.SetBusy(true, "Eintrag wird abgefragt...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", id.ToString());
			ResponseData<FullEntry> fullEntry = await InfoAPI.GetFullEntry(postParas);
			if (!fullEntry.Error)
			{
				Model.FullEntry = fullEntry.Data;
				Model.ContentCollection.Clear();
				int pages = Model.FullEntry.Count / 50;
				if (Model.FullEntry.Count % 50 > 0)
					pages++;
				if (pages == 0)
				{
					if (Model.FullEntry.Count == 1)
					{
						Model.ContentCollection.Add(new ContentWrapper(LoadContentPage) { Title = "1" });
					}
					else
					{
						Model.ContentCollection.Add(new ContentWrapper(LoadContentPage) { Title = "1-" + Model.FullEntry.Count });
					}
				}
				else
				{
					for (int i = 0; i < pages; i++)
					{
						if (i == pages - 1)
							Model.ContentCollection.Add(new ContentWrapper(LoadContentPage) { Title = "" + ((i * 50) + 1) + "-" + Model.FullEntry.Count });
						else
							Model.ContentCollection.Add(new ContentWrapper(LoadContentPage) { Title = "" + ((i * 50) + 1) + "-" + ((i + 1) * 50) });
					}
				}
				Busy.SetBusy(false);
			}
			else
			{
				HandleException(fullEntry);
			}
		}
	}
}