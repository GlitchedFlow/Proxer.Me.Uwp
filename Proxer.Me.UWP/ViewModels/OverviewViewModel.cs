using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.List;
using Proxer.Me.Support.Enums.Data;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class OverviewViewModel : PaneViewModel<OverviewModel>
	{
		public ICommand LoadNextPage { get; private set; }

		public ICommand LoadEntry { get; private set; }

		private bool blockContentLoading = false;

		public OverviewViewModel() : base(new OverviewModel())
		{
			LoadNextPage = new DelegateCommand<object>(ExecuteLoadNextPage);
			Model.AnimeMangaSource = new ObservableCollection<EntryList>();
			Model.MovieOneShotSource = new ObservableCollection<EntryList>();
			Model.OvaDoujinshiSource = new ObservableCollection<EntryList>();
			Model.HentaiSource = new ObservableCollection<EntryList>();
			Model.PropertyChanged += Model_PropertyChanged;
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

		private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (!blockContentLoading)
			{
				if (e.PropertyName == nameof(Model.SelectedContent))
				{
					Model.SelectedEntry = null;
					bool loadContent = false;
					switch (Model.SelectedContent)
					{
						case 0:
							if (Model.AnimeMangaSource.Count == 0)
								loadContent = true;
							Model.CurrentAnimeMangaPage = 0;
							Model.HasMoreAnimeManga = true;
							break;

						case 1:
							if (Model.MovieOneShotSource.Count == 0)
								loadContent = true;
							Model.CurrentMovieOneShotPage = 0;
							Model.HasMoreMovieOneShot = true;
							break;

						case 2:
							if (Model.OvaDoujinshiSource.Count == 0)
								loadContent = true;
							Model.CurrentOVADoujinshiPage = 0;
							Model.HasMoreOVADoujinshi = true;
							break;

						case 3:
							if (Model.HentaiSource.Count == 0)
								loadContent = true;
							Model.CurrentHentaiPage = 0;
							Model.HasMoreHentai = true;
							break;
					}
					if (loadContent)
					{
						LoadNextPage.Execute(null);
					}
				}
				if (e.PropertyName == nameof(Model.SelectedLetter) || e.PropertyName == nameof(Model.SelectedSorting))
				{
					Model.AnimeMangaSource.Clear();
					Model.MovieOneShotSource.Clear();
					Model.OvaDoujinshiSource.Clear();
					Model.HentaiSource.Clear();
					Model.HasMoreAnimeManga = true;
					Model.HasMoreMovieOneShot = true;
					Model.HasMoreOVADoujinshi = true;
					Model.HasMoreHentai = true;
					Model.CurrentAnimeMangaPage = 0;
					Model.CurrentMovieOneShotPage = 0;
					Model.CurrentOVADoujinshiPage = 0;
					Model.CurrentHentaiPage = 0;
					LoadNextPage.Execute(null);
				}
			}
		}

		public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
		{
			Model.AnimeMangaSource.Clear();
			Model.MovieOneShotSource.Clear();
			Model.OvaDoujinshiSource.Clear();
			Model.HentaiSource.Clear();
			Model.HasMoreAnimeManga = true;
			Model.HasMoreMovieOneShot = true;
			Model.HasMoreOVADoujinshi = true;
			Model.HasMoreHentai = true;
			Model.CurrentAnimeMangaPage = 0;
			Model.CurrentMovieOneShotPage = 0;
			Model.CurrentOVADoujinshiPage = 0;
			Model.CurrentHentaiPage = 0;
			await Task.CompletedTask;
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			await base.OnNavigatedToAsync(parameter, mode, state);
			Model.SelectedEntry = null;
			Model.OverviewType = parameter.ToString();
			if (Model.OverviewType == "Anime")
				Model.IsAnime = true;
			else
				Model.IsAnime = false;
			blockContentLoading = true;
			Model.SelectedContent = 0;
			Model.SelectedSorting = 1;
			Model.SelectedLetter = 0;
			Model.RaisePropertyChanged(nameof(Model.SelectedContent));
			blockContentLoading = false;
			LoadNextPage.Execute(null);
		}

		private async void ExecuteLoadNextPage(object parameter)
		{
			Busy.SetBusy(true, $"{Model.OverviewType} werden geladen");

			int getItemsCount = 50;

			Dictionary<string, string> postParas = new Dictionary<string, string>();

			if (Model.IsAnime)
			{
				postParas.Add("kat", "anime");
			}
			else
			{
				postParas.Add("kat", "manga");
			}
			var start = "";
			if (Model.SelectedLetter == 0)
			{
				start = "";
			}
			else if (Model.SelectedLetter == 1)
			{
				start = "nonAlpha";
			}
			else
			{
				start = ((Filter)Enum.Parse(typeof(Filter), Model.SelectedLetter.ToString())).ToString();
			}
			if (!string.IsNullOrWhiteSpace(start))
			{
				postParas.Add("start", start);
			}
			postParas.Add("medium", getMedium());
			int currentPage = 0;
			switch (Model.SelectedContent)
			{
				case 0:
					currentPage = Model.CurrentAnimeMangaPage;
					break;

				case 1:
					currentPage = Model.CurrentMovieOneShotPage;
					break;

				case 2:
					currentPage = Model.CurrentOVADoujinshiPage;
					break;

				case 3:
					currentPage = Model.CurrentHentaiPage;
					break;
			}
			postParas.Add("p", currentPage.ToString());
			postParas.Add("limit", getItemsCount.ToString());
			ResponseData<List<EntryList>> data = await ListAPI.GetEntryList(postParas);

			if (!data.Error)
			{
				switch (Model.SelectedContent)
				{
					case 0:
						if (data.Data.Count == getItemsCount)
						{
							Model.HasMoreAnimeManga = true;
							Model.CurrentAnimeMangaPage += 1;
						}
						else
							Model.HasMoreAnimeManga = false;
						foreach (var item in data.Data)
						{
							Model.AnimeMangaSource.Add(item);
						}
						break;

					case 1:
						if (data.Data.Count == getItemsCount)
						{
							Model.HasMoreMovieOneShot = true;
							Model.CurrentMovieOneShotPage += 1;
						}
						else
							Model.HasMoreMovieOneShot = false;
						foreach (var item in data.Data)
						{
							Model.MovieOneShotSource.Add(item);
						}
						break;

					case 2:
						if (data.Data.Count == getItemsCount)
						{
							Model.HasMoreOVADoujinshi = true;
							Model.CurrentOVADoujinshiPage += 1;
						}
						else
							Model.HasMoreOVADoujinshi = false;
						foreach (var item in data.Data)
						{
							Model.OvaDoujinshiSource.Add(item);
						}
						break;

					case 3:
						if (data.Data.Count == getItemsCount)
						{
							Model.HasMoreHentai = true;
							Model.CurrentHentaiPage += 1;
						}
						else
							Model.HasMoreHentai = false;
						foreach (var item in data.Data)
						{
							Model.HentaiSource.Add(item);
						}
						break;
				}

				Busy.SetBusy(false);
			}
			else
			{
				HandleException(data);
			}
		}

		private string getMedium()
		{
			if (Model.IsAnime)
			{
				switch (Model.SelectedContent)
				{
					case 0:
						return Medium.AnimeSeries.ToString().ToLower();

					case 1:
						return Medium.Movie.ToString().ToLower();

					case 2:
						return Medium.OVA.ToString().ToLower();

					case 3:
						return Medium.Hentai.ToString().ToLower();
				}
			}
			switch (Model.SelectedContent)
			{
				case 0:
					return Medium.MangaSeries.ToString().ToLower();

				case 1:
					return Medium.OneShot.ToString().ToLower();

				case 2:
					return Medium.Doujin.ToString().ToLower();

				case 3:
					return Medium.HManga.ToString().ToLower();
			}
			return "";
		}
	}
}