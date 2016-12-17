using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Proxer.Me.Support.Api.Data.List;
using Proxer.Me.Support.Enums.Data;

namespace Proxer.Me.UWP.Models
{
	public class OverviewModel : PaneModel
	{
		private string overviewType;

		public string OverviewType
		{
			get { return overviewType; }
			set { Set(ref overviewType, value); }
		}

		public bool IsAnime
		{
			get { return isAnime; }
			set
			{
				isAnime = value;
				if (value)
				{
					AnimeMangaTabName = "Animeserie";
					MovieOneShotTabName = "Movie";
					OvaDoujinshiTabName = "OVA";
					HentaiTabName = "Hentai";
				}
				else
				{
					AnimeMangaTabName = "Mangaserie";
					MovieOneShotTabName = "One-Shot";
					OvaDoujinshiTabName = "Doujinshi";
					HentaiTabName = "Hentai";
				}
				RaisePropertyChanged(nameof(ShowOVADoujinshiContent));
			}
		}

		public string AnimeMangaTabName
		{
			get { return animeMangaTabName; }
			set { Set(ref animeMangaTabName, value); }
		}

		public string MovieOneShotTabName
		{
			get { return movieOneShotTabName; }
			set { Set(ref movieOneShotTabName, value); }
		}

		public string OvaDoujinshiTabName
		{
			get { return ovaDoujinshiTabName; }
			set { Set(ref ovaDoujinshiTabName, value); }
		}

		public string HentaiTabName
		{
			get { return hentaiTabName; }
			set { Set(ref hentaiTabName, value); }
		}

		public int SelectedContent
		{
			get { return selectedContent; }
			set { Set(ref selectedContent, value); }
		}

		public ObservableCollection<EntryList> AnimeMangaSource
		{
			get { return animeMangaSource; }
			set { Set(ref animeMangaSource, value); }
		}

		public ObservableCollection<EntryList> MovieOneShotSource
		{
			get { return movieOneShotSource; }
			set { Set(ref movieOneShotSource, value); }
		}

		public ObservableCollection<EntryList> OvaDoujinshiSource
		{
			get { return ovaDoujinshiSource; }
			set { Set(ref ovaDoujinshiSource, value); }
		}

		public ObservableCollection<EntryList> HentaiSource
		{
			get { return hentaiSource; }
			set { Set(ref hentaiSource, value); }
		}

		public int CurrentAnimeMangaPage { get; set; }

		public int CurrentMovieOneShotPage { get; set; }

		public int CurrentOVADoujinshiPage { get; set; }

		public int CurrentHentaiPage { get; set; }

		public bool HasMoreAnimeManga
		{
			get { return hasMoreAnimeManga; }
			set { Set(ref hasMoreAnimeManga, value); }
		}

		public bool HasMoreMovieOneShot
		{
			get { return hasMoreMovieOneShot; }
			set { Set(ref hasMoreMovieOneShot, value); }
		}

		public bool HasMoreOVADoujinshi
		{
			get { return hasMoreOVADoujinshi; }
			set { Set(ref hasMoreOVADoujinshi, value); }
		}

		public bool HasMoreHentai
		{
			get { return hasMoreHentai; }
			set { Set(ref hasMoreHentai, value); }
		}

		public int SelectedSorting
		{
			get { return selectedSorting; }
			set { Set(ref selectedSorting, value); }
		}

		public int SelectedLetter
		{
			get { return selectedLetter; }
			set { Set(ref selectedLetter, value); }
		}

		public bool ShowOVADoujinshiContent
		{
			get
			{
				if (IsAnime)
				{
					return true;
				}
				else
				{
					return ShellModel.ShowAdultContent;
				}
			}
		}

		public List<string> LettersSource
		{
			get
			{
				if (lettersSource == null)
				{
					lettersSource = new List<string>();
					string[] names = Enum.GetNames(typeof(Filter));
					for (int i = 0; i < names.Length; i++)
					{
						if (i == 0)
						{
							lettersSource.Add("Alle");
							continue;
						}
						if (i == 1)
						{
							lettersSource.Add("0-9");
							continue;
						}
						lettersSource.Add(names[i]);
					}
				}
				return lettersSource;
			}
		}

		public EntryList SelectedEntry
		{
			get { return selectedEntry; }
			set { Set(ref selectedEntry, value); }
		}

		private bool isAnime;

		private int selectedSorting = 1;
		private int selectedLetter = 0;

		private string animeMangaTabName;
		private string movieOneShotTabName;
		private string ovaDoujinshiTabName;
		private string hentaiTabName;

		private int selectedContent;

		private bool hasMoreAnimeManga;
		private bool hasMoreMovieOneShot;
		private bool hasMoreOVADoujinshi;
		private bool hasMoreHentai;

		private List<string> lettersSource;

		private ObservableCollection<EntryList> animeMangaSource;
		private ObservableCollection<EntryList> movieOneShotSource;
		private ObservableCollection<EntryList> ovaDoujinshiSource;
		private ObservableCollection<EntryList> hentaiSource;

		private EntryList selectedEntry;
	}
}