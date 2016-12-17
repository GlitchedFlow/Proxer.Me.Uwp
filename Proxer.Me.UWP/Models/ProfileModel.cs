using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Proxer.Me.Support.Api.Data.Common;

namespace Proxer.Me.UWP.Models
{
	public class ProfileModel : PaneModel
	{
		private string username;

		public string Username
		{
			get { return username; }
			set { Set(ref username, value); }
		}

		private IDictionary<string, int> points;

		public string Status
		{
			get { return status; }
			set { Set(ref status, value); }
		}

		public int SelectedContent
		{
			get { return selectedContent; }
			set { Set(ref selectedContent, value); }
		}

		public string Avatar
		{
			get { return avatar; }
			set { Set(ref avatar, value); }
		}

		public IDictionary<string, int> Points
		{
			get { return points; }
			set { Set(ref points, value); }
		}

		public int PointsTotal
		{
			get
			{
				if (Points == null)
					return 0;
				return Points.Sum(x => x.Value);
			}
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

		private List selectedAnime;

		private List selectedManga;

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

		public ObservableCollection<TopTen> TopTenCollection
		{
			get { return topTenCollection; }
			set { Set(ref topTenCollection, value); }
		}

		public ObservableCollection<Comment> CommentCollection
		{
			get { return commentCollection; }
			set { Set(ref commentCollection, value); }
		}

		public bool HasMoreComments
		{
			get { return hasMoreComments; }
			set { Set(ref hasMoreComments, value); }
		}

		public TopTen SelectedAnimeTopTen
		{
			get { return selectedAnimeTopTen; }
			set { Set(ref selectedAnimeTopTen, value); }
		}

		public TopTen SelectedMangaTopTen
		{
			get { return selectedMangaTopTen; }
			set { Set(ref selectedMangaTopTen, value); }
		}

		public int CurrentCommentPage { get; set; }

		private bool hasMoreAnime;

		private bool hasMoreManga;

		private string status;

		private int selectedContent;

		private string avatar;

		private ObservableCollection<TopTen> topTenCollection;

		private ObservableCollection<Comment> commentCollection;

		private TopTen selectedAnimeTopTen;

		private TopTen selectedMangaTopTen;

		private bool hasMoreComments;
	}
}