using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.User;
using Proxer.Me.Records;

namespace Proxer.Me.Models
{
	public class ProfileModel : Model
	{
		private int _profileUID;

		public bool HasLoadedProfile { get; set; }

		public bool HasLoadedAnime { get; set; }
		public bool HasLoadedManga { get; set; }
		public bool HasLoadedComments { get; set; }

		public List<ProfilePointsRecord> Points { get; set; } = new List<ProfilePointsRecord>();

		public ObservableCollection<TopTenRecord> AnimeTopTen { get; } = new ObservableCollection<TopTenRecord>();

		public ObservableCollection<TopTenRecord> MangaTopTen { get; } = new ObservableCollection<TopTenRecord>();

		public ObservableCollection<ProfileListRecord> AnimeList { get; } = new ObservableCollection<ProfileListRecord>();

		public ObservableCollection<IGrouping<int, ProfileListRecord>> AnimeGrouped { get; set; } = new ObservableCollection<IGrouping<int, ProfileListRecord>>();

		public ObservableCollection<ProfileListRecord> MangaList { get; } = new ObservableCollection<ProfileListRecord>();

		public ObservableCollection<IGrouping<int, ProfileListRecord>> MangaGrouped { get; set; } = new ObservableCollection<IGrouping<int, ProfileListRecord>>();

		private string _status;

		public bool HasStatus
		{
			get { return !string.IsNullOrWhiteSpace(Status); }
		}

		public bool HasAnimeTopTen
		{
			get { return AnimeTopTen.Count > 0; }
		}

		public bool HasMangaTopTen
		{
			get { return MangaTopTen.Count > 0; }
		}

		public int PointsTotal
		{
			get
			{
				return Points.Sum(x => x.Points);
			}
		}

		public int ProfileUID
		{
			get { return _profileUID; }
			set
			{
				if (ProfileUID != value)
				{
					_profileUID = value;
					HasLoadedAnime = false;
					HasLoadedComments = false;
					HasLoadedManga = false;
					HasLoadedProfile = false;
					HasCommentNextPage = false;
					CurrentCommentPage = 0;
					AnimeList.Clear();
					MangaList.Clear();
				}
			}
		}
		private string _profileAvatar;
		public string ProfileAvatar
		{
			get
			{
				return $"https://cdn.proxer.me/avatar/{_profileAvatar}";
			}
			set
			{
				_profileAvatar = value;
				NotifyPropertyChanged();
			}
		}

		private string _profileUsername;

		private bool _mangaComments;

		public int SelectedContent
		{
			get { return _selectedContent; }
			set
			{
				_selectedContent = value;
				NotifyPropertyChanged();
			}
		}

		public string ProfileUsername
		{
			get	{ return _profileUsername; }
			set
			{
				_profileUsername = value;
				NotifyPropertyChanged();
			}
		}

		public string Status
		{
			get { return _status; }
			set
			{
				_status = value;
				NotifyPropertyChanged();
			}
		}

		private int _selectedContent = -1;

		public bool HasCommentNextPage { get; set; }

		public ObservableCollection<ProfileCommentRecord> Comments { get; } = new ObservableCollection<ProfileCommentRecord>();

		private int _currentCommentPage;

		public int CurrentCommentPage
		{
			get { return _currentCommentPage; }
			set
			{
				if (_currentCommentPage != value)
				{
					_currentCommentPage = value;
					NotifyPropertyChanged();
				}
			}
		}
	}
}
