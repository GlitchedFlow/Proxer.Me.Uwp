using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxAPI;
using Proxer.Me.ProxData.Info.Data;
using Proxer.Me.Records;
using Proxer.Me.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.ViewModels
{
	public class EntryViewModel : ViewModel<EntryModel>
	{
		static EntryViewModel()
		{
			Instance = new EntryViewModel();
		}

		public static EntryViewModel Instance { get; private set; }

		public DelegateCommand Refresh { get; private set; }

		public DelegateCommand OpenEntry { get; private set; }

		public DelegateCommand NextCommentPage { get; private set; }

		public DelegateCommand PreviousCommentPage { get; private set; }

		public EntryViewModel() : base(new EntryModel())
		{
			Refresh = new DelegateCommand(ExecuteRefresh, CanExecuteRefresh);
			OpenEntry = new DelegateCommand(ExecuteOpenEntry);
			NextCommentPage = new DelegateCommand(ExecuteNextPage, CanExecuteNextPage);
			PreviousCommentPage = new DelegateCommand(ExecutePreviousPage, CanExecutePreviousPage);
			Model.PropertyChanged += Model_PropertyChanged;
		}

		private bool CanExecutePreviousPage(object obj)
		{
			return !Model.IsWorking && Model.CurrentCommentPage > 0;
		}

		private async void ExecutePreviousPage(object obj)
		{
			Model.IsWorking = true;
			PreviousCommentPage.RaiseCanExecuteChanged();
			NextCommentPage.RaiseCanExecuteChanged();
			Model.CurrentCommentPage -= 1;
			await getComments();
			Model.IsWorking = false;
			PreviousCommentPage.RaiseCanExecuteChanged();
			NextCommentPage.RaiseCanExecuteChanged();
		}

		private bool CanExecuteNextPage(object obj)
		{
			return !Model.IsWorking && Model.HasCommentNextPage;
		}

		private async void ExecuteNextPage(object obj)
		{
			Model.IsWorking = true;
			PreviousCommentPage.RaiseCanExecuteChanged();
			NextCommentPage.RaiseCanExecuteChanged();
			Model.CurrentCommentPage += 1;
			await getComments();
			Model.IsWorking = false;
			PreviousCommentPage.RaiseCanExecuteChanged();
			NextCommentPage.RaiseCanExecuteChanged();
		}

		private void ExecuteOpenEntry(object obj)
		{
			var frame = Window.Current.Content as Frame;
			Model.EntryID = Convert.ToInt32(obj);
			frame.Navigate(typeof(EntryPage), null);
		}

		private bool _firstReload;

		private async void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(Model.SelectedInfo):
					SelectedInfoChanged();
					break;

				case nameof(Model.SelectedContent):
					SelectedContentChanged();
					break;

				case nameof(Model.CurrentEpisodePage):
					if (!_firstReload)
						await getContent();
					break;

				default:
					break;
			}
		}

		private async void SelectedContentChanged()
		{
			switch (Model.SelectedContent)
			{
				case 1:
					Model.IsWorking = true;
					PreviousCommentPage.RaiseCanExecuteChanged();
					NextCommentPage.RaiseCanExecuteChanged();
					await getComments();
					Model.IsWorking = false;
					PreviousCommentPage.RaiseCanExecuteChanged();
					NextCommentPage.RaiseCanExecuteChanged();
					break;

				case 2:
					await getRelations();
					break;
			}
		}

		private async void SelectedInfoChanged()
		{
			switch (Model.SelectedInfo)
			{
				case 1:
					await getNames();
					break;

				case 3:
					await getTags();
					break;

				case 4:
					await getGroups();
					await getPublishers();
					break;

				case 5:
					await getSeasons();
					break;

				default:
					break;
			}
		}

		private bool CanExecuteRefresh(object obj)
		{
			return !Model.IsWorking;
		}

		private async void ExecuteRefresh(object obj)
		{
			Model.IsWorking = true;
			var detailsFinished = await getDetails();
			if (detailsFinished)
			{
				await getContent();
			}
			Model.IsWorking = false;
		}

		private async Task getContent()
		{
			if (Model.LoadedEpisodes)
			{
				Model.LoadedEpisodes = false;
			}
			var list = await InfoAPI.GetListInfo(Model.EntryID, Model.CurrentEpisodePage);
			if (list.Error)
			{
				_hasShowedError = true;
				ErrorHandler.ShowError(list.Code);
			}
			else if (!list.Error)
			{
				Model.Languages.Clear();
				List<List<EpisodeData>> languages = new List<List<EpisodeData>>();
				var languagesWithContent = new Dictionary<string, List<EntryContentLanguage>>();
				foreach (var lang in list.Data.Languages)
				{
					languages.Add(list.Data.Episodes.Where(x => x.Type == lang).ToList());
					languagesWithContent.Add(lang, new List<EntryContentLanguage>());
					Model.Languages.Add(new EntryLanguageRecord(lang, list.Data.Languages.IndexOf(lang)));
				}
				var preList = 0;
				languages.ForEach((x) =>
				{
					if (x.Count - 1 > preList)
						preList = x.Count - 1;
				});
				foreach (var lang in languages)
				{
					var index = languages.IndexOf(lang);
					for (int i = 0; i <= preList; i++)
					{
						if (lang.Count > 0 & lang.Count(x => x.Number == list.Data.Start + i) == 1)
						{
							languagesWithContent[Model.Languages.ToList()[index].Language.ToLower()].Add(new EntryContentLanguage(lang[i].Title,
								list.Data.Category == "anime",
								Model.Data.Details.Name,
								lang[i].Number,
								lang[i].Type,
								list.Data.Category == "anime" ? lang[i].Types.Split(',') : null,
								list.Data.Category == "anime" ? lang[i].HosterImgs.Split(',') : null));
						}
						else
						{
							languagesWithContent[Model.Languages.ToList()[index].Language.ToLower()].Add(new EntryContentLanguage(
								list.Data.Category == "anime",
								Model.Data.Details.Name,
								list.Data.Start + i));
						}
					}
				}
				Model.Content.Clear();
				for (int i = 0; i <= preList; i++)
				{
					var content = new List<EntryContentLanguage>();
					list.Data.Languages.ForEach(x => content.Add(languagesWithContent[x][i]));
					Model.Content.Add(new EntryContentRecord(list.Data.Start + i, Model.EntryID, list.Data.State >= list.Data.Start + i, content));
				}
				Model.LoadedEpisodes = true;
			}
		}

		private async Task getRelations()
		{
			if (!Model.LoadedRelations)
			{
				var relations = await InfoAPI.GetRelations(Model.EntryID);
				if (relations.Error)
				{
					_hasShowedError = true;
					ErrorHandler.ShowError(relations.Code);
				}
				else if (!relations.Error)
				{
					Model.Relations.Clear();
					foreach (var relation in relations.Data)
					{
						Model.Relations.Add(new RelationRecord(relation));
					}
					Model.LoadedRelations = true;
				}
			}
		}

		private async Task getComments()
		{
			Model.HasCommentNextPage = false;
			if (Model.LoadedComments)
			{
				Model.LoadedComments = false;
			}
			var comments = await InfoAPI.GetComments(Model.EntryID, Model.CurrentCommentPage, 26);
			if (comments.Error)
			{
				_hasShowedError = true;
				ErrorHandler.ShowError(comments.Code);
			}
			else if (!comments.Error)
			{
				if (comments.Data.Count == 26)
					Model.HasCommentNextPage = true;
				Model.Comments.Clear();
				foreach (var item in comments.Data)
				{
					if (comments.Data.Count == 26 && comments.Data.IndexOf(item) == 25)
						continue;
					Model.Comments.Add(new EntryCommentRecord(item, Model.Data.Details.Category == "manga"));
				}
				Model.LoadedComments = true;
			}
		}

		private async Task<bool> getDetails()
		{
			if (!Model.LoadedDetails)
			{
				var details = await InfoAPI.GetEntry(Model.EntryID);
				if (details.Error)
				{
					_hasShowedError = true;
					ErrorHandler.ShowError(details.Code);
					return false;
				}
				else if (!details.Error)
				{
					Model.Data.Details = details.Data;
					Model.Pages.Clear();
					Model.SelectedContentPage = null;
					var pagesCount = Model.Data.Details.Count / 50;
					if (pagesCount > 1)
					{
						for (int i = 0; i < pagesCount; i++)
						{
							var content = (1 + (i * 50)) + "-" + ((i + 1) * 50);
							Model.Pages.Add(new EntryContentPageRecord(i, content));
							_firstReload = true;
							Model.SelectedContentPage = Model.Pages[0];
							_firstReload = false;
						}
					}
					foreach (var item in Model.Data.Details.FSK.Split(' '))
					{
						Model.Data.Fsk.Add(new FSKRecord(item));
					}
					Model.Data.Tags.Clear();
					foreach (var item in Model.Data.Details.Genre.Split(' '))
					{
						Model.Data.Tags.Add(new TagRecord(item));
					}
					Model.LoadedDetails = true;
				}
			}
			return true;
		}

		private async Task getNames()
		{
			if (!Model.LoadedNames)
			{
				var names = await InfoAPI.GetNames(Model.EntryID);
				if (names.Error)
				{
					_hasShowedError = true;
					ErrorHandler.ShowError(names.Code);
				}
				else if (!names.Error)
				{
					Model.LoadedNames = true;
					Model.Data.Names.Clear();
					foreach (var name in names.Data)
					{
						Model.Data.Names.Add(new NameRecord(name));
					}
				}
			}
		}

		private async Task getTags()
		{
			if (!Model.LoadedTags)
			{
				var tags = await InfoAPI.GetTags(Model.EntryID);
				if (tags.Error)
				{
					_hasShowedError = true;
					ErrorHandler.ShowError(tags.Code);
				}
				else if (!tags.Error)
				{
					Model.LoadedTags = true;
					Model.Data.Tags.Clear();
					foreach (var item in Model.Data.Details.Genre.Split(' '))
					{
						Model.Data.Tags.Add(new TagRecord(item));
					}
					foreach (var tag in tags.Data)
					{
						Model.Data.Tags.Add(new TagRecord(tag));
					}
				}
			}
		}

		private async Task getSeasons()
		{
			if (!Model.LoadedSeasons)
			{
				var seasons = await InfoAPI.GetSeason(Model.EntryID);
				if (seasons.Error && !_hasShowedError)
				{
					_hasShowedError = true;
					ErrorHandler.ShowError(seasons.Code);
				}
				else if (!seasons.Error)
				{
					Model.LoadedSeasons = true;
					Model.Data.Seasons.Clear();
					foreach (var season in seasons.Data)
					{
						Model.Data.Seasons.Add(season);
					}
				}
			}
		}

		private async Task getGroups()
		{
			if (!Model.LoadedGroups)
			{
				var groups = await InfoAPI.GetGroups(Model.EntryID);
				if (groups.Error)
				{
					_hasShowedError = true;
					ErrorHandler.ShowError(groups.Code);
				}
				else if (!groups.Error)
				{
					Model.LoadedGroups = true;
					Model.Data.People.Clear();
					foreach (var group in groups.Data)
					{
						Model.Data.People.Add(new PeopleRecord(group));
					}
				}
			}
		}

		private async Task getPublishers()
		{
			if (!Model.LoadedPublishers)
			{
				var publishers = await InfoAPI.GetPublisher(Model.EntryID);
				if (publishers.Error)
				{
					_hasShowedError = true;
					ErrorHandler.ShowError(publishers.Code);
				}
				else if (!publishers.Error)
				{
					Model.LoadedPublishers = true;
					foreach (var publisher in publishers.Data)
					{
						Model.Data.People.Add(new PeopleRecord(publisher));
					}
				}
			}
		}

		public override void RefreshPageContent()
		{
			base.RefreshPageContent();
			Refresh.Execute(null);
		}
	}
}