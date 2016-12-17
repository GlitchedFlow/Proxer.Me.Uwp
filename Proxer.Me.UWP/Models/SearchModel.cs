using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Proxer.Me.Support.Api.Data.List;
using Proxer.Me.Support.Enums.Data;
using Proxer.Me.Support.Records;

namespace Proxer.Me.UWP.Models
{
	public class SearchModel : PaneModel
	{
		private string title;

		public string Title
		{
			get { return title; }
			set { Set(ref title, value); }
		}

		public bool BothLanguages
		{
			get { return bothLanguages; }
			set { Set(ref bothLanguages, value); }
		}

		public bool GermanOnly
		{
			get { return germanOnly; }
			set { Set(ref germanOnly, value); }
		}

		public bool EnglishOnly
		{
			get { return englishOnly; }
			set { Set(ref englishOnly, value); }
		}

		public bool HasMoreResults
		{
			get { return hasMoreResults; }
			set { Set(ref hasMoreResults, value); }
		}

		public ObservableCollection<EntrySearch> SearchResult
		{
			get { return searchResult; }
			set { Set(ref searchResult, value); }
		}

		private ObservableCollection<EntrySearch> searchResult;

		private bool bothLanguages = true;

		private bool germanOnly;

		private bool englishOnly;

		private bool hasMoreResults;

		private IEnumerable<IGrouping<char, SearchGenre>> genres;

		public IEnumerable<IGrouping<char, SearchGenre>> Genres
		{
			get { return genres; }
			set { Set(ref genres, value); }
		}

		private IEnumerable<IGrouping<char, SearchTag>> tags;

		public IEnumerable<IGrouping<char, SearchTag>> Tags
		{
			get { return tags; }
			set { Set(ref tags, value); }
		}

		public int CurrentPage { get; set; } = 0;

		public bool All
		{
			get { return all; }
			set { Set(ref all, value); }
		}

		public bool AllWithExplicit
		{
			get { return allWithExplicit; }
			set { Set(ref allWithExplicit, value); }
		}

		public bool AllAnime
		{
			get { return allAnime; }
			set { Set(ref allAnime, value); }
		}

		public bool AnimeSerie
		{
			get { return animeSerie; }
			set { Set(ref animeSerie, value); }
		}

		public bool Movie
		{
			get { return movie; }
			set { Set(ref movie, value); }
		}

		public bool OVA
		{
			get { return oVA; }
			set { Set(ref oVA, value); }
		}

		public bool Hentai
		{
			get { return hentai; }
			set { Set(ref hentai, value); }
		}

		public bool AllManga
		{
			get { return allManga; }
			set { Set(ref allManga, value); }
		}

		public bool MangaSerie
		{
			get { return mangaSerie; }
			set { Set(ref mangaSerie, value); }
		}

		public bool OneShot
		{
			get { return oneShot; }
			set { Set(ref oneShot, value); }
		}

		public bool Doujinshi
		{
			get { return doujinshi; }
			set { Set(ref doujinshi, value); }
		}

		public bool HManga
		{
			get { return hManga; }
			set { Set(ref hManga, value); }
		}

		public bool? SpoilerState
		{
			get { return spoilerState; }
			set
			{
				Set(ref spoilerState, value);
				RaisePropertyChanged(nameof(SpoilerStateString));
			}
		}

		public string SpoilerStateString
		{
			get
			{
				if (SpoilerState == null)
					return "Nur Spoiler Tags";
				if (SpoilerState == true)
					return "Spoiler Tags einbeziehen";
				return "Spoiler Tags ignorieren";
			}
		}

		public bool TagFilterState
		{
			get { return tagFilterState; }
			set { Set(ref tagFilterState, value); }
		}

		public string TagQuickSearch
		{
			get { return tagQuickSearch; }
			set { Set(ref tagQuickSearch, value); }
		}

		public bool Psk0
		{
			get { return psk0; }
			set { Set(ref psk0, value); }
		}

		public bool Psk6
		{
			get { return psk6; }
			set { Set(ref psk6, value); }
		}

		public bool Psk12
		{
			get { return psk12; }
			set { Set(ref psk12, value); }
		}

		public bool Psk16
		{
			get { return psk16; }
			set { Set(ref psk16, value); }
		}

		public bool Psk18
		{
			get { return psk18; }
			set { Set(ref psk18, value); }
		}

		public bool BadLanguage
		{
			get { return badLanguage; }
			set { Set(ref badLanguage, value); }
		}

		public bool Violence
		{
			get { return violence; }
			set { Set(ref violence, value); }
		}

		public bool Fear
		{
			get { return fear; }
			set { Set(ref fear, value); }
		}

		public bool Sex
		{
			get { return sex; }
			set { Set(ref sex, value); }
		}

		public bool Relevance
		{
			get { return relevance; }
			set { Set(ref relevance, value); }
		}

		public bool Name
		{
			get { return name; }
			set { Set(ref name, value); }
		}

		public bool Rating
		{
			get { return rating; }
			set { Set(ref rating, value); }
		}

		public bool Clicks
		{
			get { return clicks; }
			set { Set(ref clicks, value); }
		}

		public bool Count
		{
			get { return count; }
			set { Set(ref count, value); }
		}

		public int Episodes
		{
			get { return episodes; }
			set { Set(ref episodes, value); }
		}

		public bool Under
		{
			get { return under; }
			set { Set(ref under, value); }
		}

		public bool Over
		{
			get { return over; }
			set { Set(ref over, value); }
		}

		public bool HasResults
		{
			get { return hasResults; }
			set { Set(ref hasResults, value); }
		}

		public bool ShowSearchParameter
		{
			get { return showSearchParameter; }
			set { Set(ref showSearchParameter, value); }
		}

		public EntrySearch SelectedEntry
		{
			get { return selectedEntry; }
			set { Set(ref selectedEntry, value); }
		}

		private bool tagFilterState;

		private bool all = true;

		private bool allWithExplicit;

		private bool allAnime;

		private bool animeSerie;

		private bool movie;

		private bool oVA;

		private bool hentai;

		private bool allManga;

		private bool mangaSerie;

		private bool oneShot;

		private bool doujinshi;

		private bool hManga;

		private bool? spoilerState = false;

		private string tagQuickSearch;

		private bool psk0;

		private bool psk6;

		private bool psk12;

		private bool psk16;

		private bool psk18;

		private bool badLanguage;

		private bool violence;

		private bool fear;

		private bool sex;

		private bool relevance = true;

		private bool name;

		private bool rating;

		private bool clicks;

		private bool count;

		private int episodes;

		private bool under = true;

		private bool over;

		private bool hasResults = false;

		private bool showSearchParameter = true;

		private EntrySearch selectedEntry;

		public SearchModel()
		{
			var _genres = Enum.GetNames(typeof(Genre));
			var _records = new List<SearchGenre>();
			_genres.ToList().ForEach(x => _records.Add(new SearchGenre((Genre)Enum.Parse(typeof(Genre), x))));
			Genres = _records.GroupBy(x => x.DisplayName[0]);
		}
	}
}