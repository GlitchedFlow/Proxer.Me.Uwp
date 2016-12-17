using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.List;
using Proxer.Me.Support.Attributes;
using Proxer.Me.Support.Records;
using Proxer.Me.UWP.Core;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class SearchViewModel : PaneViewModel<SearchModel>
	{
		public ICommand LoadNextPage { get; private set; }

		public ICommand StartSearch { get; private set; }

		public ICommand ClearSearch { get; private set; }

		public ICommand SetTag { get; private set; }

		public ICommand LoadEntry { get; private set; }

		public SearchViewModel() : base(new SearchModel())
		{
			LoadNextPage = new DelegateCommand(ExecuteLoadNextPage, CanExecuteLoadNextPage);
			StartSearch = new DelegateCommand(ExecuteStartSearch);
			ClearSearch = new DelegateCommand(ExecuteClearSearch);
			SetTag = new DelegateCommand(ExecuteSetTag);
			Model.SearchResult = new ObservableCollection<EntrySearch>();
			LoadEntry = new DelegateCommand(ExecuteLoadEntry);
		}

		private async void ExecuteLoadEntry()
		{
			await Task.Delay(50);
			if (Model.SelectedEntry != null)
			{
				await BootStrapper.Current.NavigationService.NavigateAsync(typeof(EntryPage), Model.SelectedEntry.ID);
			}
		}

		private void ExecuteSetTag()
		{
			if (Model.TagQuickSearch != null)
			{
				setTag();
			}
		}

		private void setTag()
		{
			if (Model.TagQuickSearch.StartsWith("-"))
			{
				Model.Tags.ToList().ForEach(
					x => x.ToList().ForEach(
						y => setState(null, y, true)));
			}
			else if (Model.TagQuickSearch.StartsWith("/"))
			{
				Model.Tags.ToList().ForEach(
					x => x.ToList().ForEach(
						y => setState(false, y, true)));
			}
			else
			{
				Model.Tags.ToList().ForEach(
					x => x.ToList().ForEach(
						y => setState(true, y, false)));
			}
		}

		private void setState(bool? state, SearchTag tag, bool hasPresign)
		{
			if (hasPresign && !string.IsNullOrWhiteSpace(Model.TagQuickSearch))
			{
				if (Model.TagQuickSearch.ToLower().Substring(1, Model.TagQuickSearch.Length - 1) == tag.DisplayName.ToLower())
				{
					tag.State = state;
					Model.TagQuickSearch = "";
				}
			}
			else if (!string.IsNullOrWhiteSpace(Model.TagQuickSearch))
			{
				if (Model.TagQuickSearch.ToLower().Substring(0, Model.TagQuickSearch.Length) == tag.DisplayName.ToLower())
				{
					tag.State = state;
					Model.TagQuickSearch = "";
				}
			}
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			await fillTags();
			await base.OnNavigatedToAsync(parameter, mode, state);
			await Task.Delay(500);
			Model.ShowSearchParameter = true;
		}

		private void ExecuteClearSearch()
		{
			Model.Title = "";
			Model.BothLanguages = true;
			Model.All = true;
			Model.Genres.ToList().ForEach(x => x.ToList().ForEach(y => y.State = false));
			Model.TagQuickSearch = "";
			Model.TagFilterState = false;
			Model.SpoilerState = false;
			Model.Tags.ToList().ForEach(x => x.ToList().ForEach(y => y.State = false));
			Model.Relevance = true;
			Model.Psk0 = false;
			Model.Psk6 = false;
			Model.Psk12 = false;
			Model.Psk16 = false;
			Model.Psk18 = false;
			Model.BadLanguage = false;
			Model.Fear = false;
			Model.Sex = false;
			Model.Violence = false;
			Model.Episodes = 0;
			Model.Under = true;
		}

		private void ExecuteStartSearch()
		{
			Model.CurrentPage = 0;
			Model.SearchResult.Clear();
			ExecuteLoadNextPage();
		}

		private bool CanExecuteLoadNextPage()
		{
			return true;
		}

		private async void ExecuteLoadNextPage()
		{
			Busy.SetBusy(true, "Treffer werden gesucht...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			int getItemsCount = 50;
			postParas.Add("name", Model.Title);
			addLanguageParameter(postParas);
			addTypeParameter(postParas);
			addGenreParameters(postParas);
			addPSKParameters(postParas);
			addSortParameter(postParas);
			addLengthParameter(postParas);
			addTagParameters(postParas);
			postParas.Add("p", Model.CurrentPage.ToString());
			postParas.Add("limit", getItemsCount.ToString());
			ResponseData<List<EntrySearch>> results = await ListAPI.GetEntrySearch(postParas);
			if (!results.Error)
			{
				if (results.Data.Count == 0)
					Model.HasResults = false;
				else
					Model.HasResults = true;
				if (results.Data.Count == getItemsCount)
				{
					Model.HasMoreResults = true;
					Model.CurrentPage++;
				}
				else
				{
					Model.HasMoreResults = false;
				}
				foreach (var item in results.Data)
				{
					Model.SearchResult.Add(item);
				}
				Busy.SetBusy(false);
				if (Model.PaneDisplayMode == SplitViewDisplayMode.Overlay)
					Model.IsPaneOpen = false;
			}
			else
			{
				HandleException(results);
			}
		}

		private void addTagParameters(Dictionary<string, string> postParas)
		{
			if (Model.Tags != null)
			{
				string value = "";
				Model.Tags.ToList().ForEach(
					x => x.ToList().Where(
						y => y.State == true).ToList().ForEach(
							z => value += z.ID + " "
							)
						);
				postParas.Add("tags", value.Trim());
				value = "";
				Model.Tags.ToList().ForEach(
					x => x.ToList().Where(
						y => y.State == null).ToList().ForEach(
							z => value += z.ID + " "
							)
						);
				postParas.Add("notags", value.Trim());
				value = "";
				if (Model.TagFilterState)
				{
					value = "rate_1";
				}
				else
				{
					value = "rate_10";
				}
				postParas.Add("tagratefilter", value);
				value = "";
				if (Model.SpoilerState == true || Model.SpoilerState == null)
				{
					if (Model.SpoilerState == true)
					{
						value = "spoiler_10";
					}
					else
					{
						value = "spoiler_1";
					}
					postParas.Add("tagspoilerfilter", "spoiler_1");
				}
			}
		}

		private void addLengthParameter(Dictionary<string, string> postParas)
		{
			if (Model.Episodes == 0)
				return;
			postParas.Add("length", Model.Episodes.ToString());
			postParas.Add("length", Model.Under ? "down" : "up");
		}

		private void addSortParameter(Dictionary<string, string> postParas)
		{
			string value = "";
			if (Model.Relevance)
				return;
			else if (Model.Clicks)
			{
				value = "clicks";
			}
			else if (Model.Rating)
			{
				value = "rating";
			}
			else if (Model.Count)
			{
				value = "count";
			}
			else
			{
				value = "name";
			}
			postParas.Add("sort", value);
		}

		private void addPSKParameters(Dictionary<string, string> postParas)
		{
			string value = "";
			if (Model.Psk0)
			{
				value += "fsk0 ";
			}
			if (Model.Psk6)
			{
				value += "fsk6 ";
			}
			if (Model.Psk12)
			{
				value += "fsk12 ";
			}
			if (Model.Psk16)
			{
				value += "fsk16 ";
			}
			if (Model.Psk18)
			{
				value += "fsk18 ";
			}
			if (Model.BadLanguage)
			{
				value += "bad_language ";
			}
			if (Model.Fear)
			{
				value += "fear ";
			}
			if (Model.Sex)
			{
				value += "sex ";
			}
			if (Model.Violence)
			{
				value += "violence ";
			}
			postParas.Add("fsk", value.Trim());
		}

		private void addGenreParameters(Dictionary<string, string> postParas)
		{
			string value = "";
			Model.Genres.ToList().ForEach(
				x => x.ToList().Where(
					y => y.State == true).ToList().ForEach(
						z => value += z.Genre.GetType().GetRuntimeField(z.Genre.ToString()).GetCustomAttribute<GenreNameAttribute>().ApiName + " "
						)
				);
			postParas.Add("genre", value.Trim());
			value = "";
			Model.Genres.ToList().ForEach(
				x => x.ToList().Where(
					y => y.State == null).ToList().ForEach(
						z => value += z.Genre.GetType().GetRuntimeField(z.Genre.ToString()).GetCustomAttribute<GenreNameAttribute>().ApiName + " "
						)
				);
			postParas.Add("nogenre", value.Trim());
		}

		private void addTypeParameter(Dictionary<string, string> postParas)
		{
			string value = "";
			if (Model.All)
				return;
			if (Model.AnimeSerie)
			{
				value = "animeseries";
			}
			else if (Model.Movie)
			{
				value = "movie";
			}
			else if (Model.OVA)
			{
				value = "ova";
			}
			else if (Model.Hentai)
			{
				value = "hentai";
			}
			else if (Model.MangaSerie)
			{
				value = "mangaseries";
			}
			else if (Model.OneShot)
			{
				value = "oneshot";
			}
			else if (Model.Doujinshi)
			{
				value = "doujin";
			}
			else if (Model.HManga)
			{
				value = "hmanga";
			}
			else if (Model.AllAnime)
			{
				value = "all-anime";
			}
			else if (Model.AllManga)
			{
				value = "all-manga";
			}
			else
			{
				value = "all18";
			}
			postParas.Add("type", value);
		}

		private void addLanguageParameter(Dictionary<string, string> postParas)
		{
			string value = "";
			if (Model.GermanOnly)
			{
				value = "de";
			}
			else if (Model.EnglishOnly)
			{
				value = "en";
			}
			postParas.Add("language", value);
		}

		private async Task fillTags()
		{
			Model.Tags = null;
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			ResponseData<List<Tag>> tags = await ListAPI.GetTags(postParas);
			if (tags.Error)
			{
				HandleException(tags);
			}
			else
			{
				var tagList = new List<SearchTag>();
				foreach (var item in tags.Data)
				{
					tagList.Add(new SearchTag(item.Name, item.Description, item.ID));
				}
				if (Model.ShellModel.ShowAdultContent)
				{
					postParas.Add("type", "entry_tag_h");
					ResponseData<List<Tag>> hTags = await ListAPI.GetTags(postParas);
					if (hTags.Error)
					{
						Info.SetInfo(true, ErrorHandler.GetErrorMessage(tags));
					}
					else
					{
						foreach (var item in hTags.Data)
						{
							tagList.Add(new SearchTag(item.Name, item.Description, item.ID));
						}
					}
				}
				Model.Tags = tagList.OrderBy(x => x.DisplayName).GroupBy(x => x.SortKey);
			}
		}
	}
}