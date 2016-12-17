using System.Collections.ObjectModel;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.UCP;

namespace Proxer.Me.UWP.Models
{
	public class UserControlPanelModel : ProxerModel
	{
		private int selectedContent;

		public int SelectedContent
		{
			get { return selectedContent; }
			set { Set(ref selectedContent, value); }
		}

		public ObservableCollection<List> AnimeCollection
		{
			get { return animeCollection; }
			set { Set(ref animeCollection, value); }
		}

		public ObservableCollection<List> MangaCollection
		{
			get { return mangaCollection; }
			set { Set(ref mangaCollection, value); }
		}

		private ObservableCollection<List> animeCollection;

		private ObservableCollection<List> mangaCollection;

		public int CurrentAnimePage { get; set; }

		public int CurrentMangaPage { get; set; }

		public bool HasMoreAnime
		{
			get { return hasMoreAnime; }
			set { Set(ref hasMoreAnime, value); }
		}

		public bool HasMoreManga
		{
			get { return hasMoreManga; }
			set { Set(ref hasMoreManga, value); }
		}

		private bool hasMoreAnime;

		private bool hasMoreManga;

		public int CurrentReminderPage { get; set; }

		public bool HasMoreReminder
		{
			get { return hasMoreReminder; }
			set { Set(ref hasMoreReminder, value); }
		}

		public ObservableCollection<Reminder> ReminderCollection
		{
			get { return reminderCollection; }
			set { Set(ref reminderCollection, value); }
		}

		public ObservableCollection<TopTen> TopTenCollection
		{
			get { return topTenCollection; }
			set { Set(ref topTenCollection, value); }
		}

		public bool HasMoreHistory
		{
			get { return hasMoreHistory; }
			set { Set(ref hasMoreHistory, value); }
		}

		private bool hasMoreReminder;

		private ObservableCollection<Reminder> reminderCollection;

		private ObservableCollection<TopTen> topTenCollection;

		private bool hasMoreHistory;

		public int CurrentHistoryPage { get; set; }

		public ObservableCollection<History> HistoryCollection
		{
			get { return historyCollection; }
			set { Set(ref historyCollection, value); }
		}

		public ObservableCollection<Vote> VoteCollection
		{
			get { return voteCollection; }
			set { Set(ref voteCollection, value); }
		}

		public List SelectedAnime
		{
			get { return selectedAnime; }
			set { Set(ref selectedAnime, value); }
		}

		public List SelectedManga
		{
			get { return selectedManga; }
			set { Set(ref selectedManga, value); }
		}

		public Reminder SelectedAnimeReminder
		{
			get { return selectedAnimeReminder; }
			set { Set(ref selectedAnimeReminder, value); }
		}

		public TopTen SelectedAnimeTopTen
		{
			get { return selectedAnimeTopTen; }
			set { Set(ref selectedAnimeTopTen, value); }
		}

		public History SelectedHistory
		{
			get { return selectedHistory; }
			set { Set(ref selectedHistory, value); }
		}

		public Reminder SelectedMangaReminder
		{
			get { return selectedMangaReminder; }
			set { Set(ref selectedMangaReminder, value); }
		}

		public TopTen SelectedMangaTopTen
		{
			get { return selectedMangaTopTen; }
			set { Set(ref selectedMangaTopTen, value); }
		}

		private ObservableCollection<History> historyCollection;

		private ObservableCollection<Vote> voteCollection;

		private List selectedAnime;

		private List selectedManga;

		private Reminder selectedAnimeReminder;

		private Reminder selectedMangaReminder;

		private TopTen selectedAnimeTopTen;

		private TopTen selectedMangaTopTen;

		private History selectedHistory;
	}
}