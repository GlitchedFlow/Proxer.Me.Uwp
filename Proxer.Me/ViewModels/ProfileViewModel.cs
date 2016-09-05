using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxAPI;
using Proxer.Me.Records;
using Proxer.Me.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.ViewModels
{
	public class ProfileViewModel : ViewModel<ProfileModel>
	{
		static ProfileViewModel()
		{
			Instance = new ProfileViewModel();
		}

		public static ProfileViewModel Instance { get; private set; }

		public DelegateCommand OpenProfile { get; private set; }

		public DelegateCommand OpenEntry { get; private set; }

		public DelegateCommand NextCommentPage { get; private set; }

		public DelegateCommand PreviousCommentPage { get; private set; }

		public ProfileViewModel() : base(new ProfileModel())
		{
			OpenProfile = new DelegateCommand(ExecuteOpenProfile);
			NextCommentPage = new DelegateCommand(ExecuteNextPage, CanExecuteNextPage);
			PreviousCommentPage = new DelegateCommand(ExecutePreviousPage, CanExecutePreviousPage);
			OpenEntry = new DelegateCommand(ExecuteOpenEntry);
			Model.PropertyChanged += Model_PropertyChanged;
		}

		private void ExecuteOpenEntry(object obj)
		{
			if (obj != null && obj is ProfileCommentRecord)
			{
				if ((obj as ProfileCommentRecord).IsManga)
				{
					MangaOverviewViewModel.Instance.OpenEntry.Execute((obj as ProfileCommentRecord).TID);
				}
				else
				{
					AnimeOverviewViewModel.Instance.OpenEntry.Execute((obj as ProfileCommentRecord).TID);
				}
			}
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

		private async void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(Model.SelectedContent):
					await SelectedContentChanged();
					break;
				default:
					break;
			}
		}

		private async Task SelectedContentChanged()
		{
			switch (Model.SelectedContent)
			{
				case 0:
					if (!Model.HasLoadedProfile)
					{
						Model.IsWorking = true;
						await getUserData();
						await getTopTen();
						await getTopTen(true);
						Model.IsWorking = false;
						Model.HasLoadedProfile = true;
					}
					break;
				case 1:
					if (!Model.HasLoadedAnime)
					{
						await getList();
						Model.HasLoadedAnime = true;
					}
					break;
				case 2:
					if (!Model.HasLoadedManga)
					{
						await getList(true);
						Model.HasLoadedManga = true;
					}
					break;
				case 3:
					if (!Model.HasLoadedComments)
					{
						await getComments();
						PreviousCommentPage.RaiseCanExecuteChanged();
						NextCommentPage.RaiseCanExecuteChanged();
						Model.HasLoadedComments = true;
					}
					break;
				default:
					break;
			}
		}

		private void ExecuteOpenProfile(object obj)
		{
			Model.ProfileUID = (int)obj;
			var frame = Window.Current.Content as Frame;
			frame.Navigate(typeof(ProfilePage), null);
		}

		public override void RefreshPageContent()
		{
			base.RefreshPageContent();
			Model.SelectedContent = 0;
		}

		private async Task getUserData()
		{
			var infos = await UserAPI.GetUserInfo(Model.ProfileUID);
			Model.Points = null;
			if (infos.Error)
			{
				ErrorHandler.ShowError(infos.Code);
			}
			else
			{
				Model.Points = new List<ProfilePointsRecord>();
				Model.Points.Add(new ProfilePointsRecord("Anime", infos.Data.PointsAnime));
				Model.Points.Add(new ProfilePointsRecord("Manga", infos.Data.PointsManga));
				Model.Points.Add(new ProfilePointsRecord("Uploads", infos.Data.PointsUploads));
				Model.Points.Add(new ProfilePointsRecord("Forum", infos.Data.PointsForum));
				Model.Points.Add(new ProfilePointsRecord("Info", infos.Data.PointsInfo));
				Model.Points.Add(new ProfilePointsRecord("Zsp.", infos.Data.PointsMisc));
				Model.NotifyPropertyChanged(nameof(Model.Points));
				Model.NotifyPropertyChanged(nameof(Model.PointsTotal));
				Model.Status = infos.Data.Status;
				Model.ProfileAvatar = infos.Data.Avatar;
				Model.ProfileUsername = infos.Data.Username;
			}
		}

		private async Task getTopTen(bool Manga = false)
		{
			var topTen = await UserAPI.GetTopTen(Model.ProfileUID, Manga);
			if (Manga)
				Model.MangaTopTen.Clear();
			else
				Model.AnimeTopTen.Clear();
			if (topTen.Error)
			{
				ErrorHandler.ShowError(topTen.Code);
			}
			else
			{
				if (Manga)
				{
					foreach (var item in topTen.Data)
					{
						Model.MangaTopTen.Add(new TopTenRecord(item.EID));
					}
				}
				else
				{
					foreach (var item in topTen.Data)
					{
						Model.AnimeTopTen.Add(new TopTenRecord(item.EID));
					}
				}
			}
		}

		private async Task getList(bool Manga = false)
		{
			Model.IsWorking = true;
			bool hasMoreContent = true;
			int page = 0;
			if (Manga)
			{
				while (hasMoreContent)
				{
					var list = await UserAPI.GetList(Model.ProfileUID, Manga, page, 5001);
					if (list.Error)
					{
						ErrorHandler.ShowError(list.Code);
						hasMoreContent = false;
					}
					else
					{
						if (list.Data.Count == 5001)
						{
							hasMoreContent = true;
							page++;
						}
						else
							hasMoreContent = false;
						foreach (var item in list.Data)
						{
							if (list.Data.Count == 5001 && list.Data.IndexOf(item) == 5000)
								continue;
							Model.MangaList.Add(new ProfileListRecord(item));
						}
						var groups = Model.MangaList.GroupBy(x => x.Data.CommentState);
						Model.MangaGrouped.Clear();
						foreach (var group in groups)
						{
							Model.MangaGrouped.Add(group);
						}
						await Task.Delay(2500);
					}
				}
			}
			else
			{
				while (hasMoreContent)
				{
					var list = await UserAPI.GetList(Model.ProfileUID, Manga, page, 5001);
					if (list.Error)
					{
						ErrorHandler.ShowError(list.Code);
						hasMoreContent = false;
					}
					else
					{
						if (list.Data.Count == 5001)
						{
							hasMoreContent = true;
							page++;
						}
						else
							hasMoreContent = false;
						foreach (var item in list.Data)
						{
							if (list.Data.Count == 5001 && list.Data.IndexOf(item) == 5000)
								continue;
							Model.AnimeList.Add(new ProfileListRecord(item));
						}
						var groups = Model.AnimeList.GroupBy(x => x.Data.CommentState);
						Model.AnimeGrouped.Clear();
						foreach (var group in groups)
						{
							Model.AnimeGrouped.Add(group);
						}
						await Task.Delay(2500);
					}
				}
			}
			Model.IsWorking = false;
		}

		private async Task getComments()
		{
			Model.IsWorking = true;
			Model.Comments.Clear();
			var comments = await UserAPI.GetComments(Model.ProfileUID, false, Model.CurrentCommentPage, 26);
			if (comments.Error)
			{
				ErrorHandler.ShowError(comments.Code);
			}
			else
			{
				if (comments.Data.Count == 26)
					Model.HasCommentNextPage = true;
				Model.Comments.Clear();
				foreach (var item in comments.Data)
				{
					if (comments.Data.Count == 26 && comments.Data.IndexOf(item) == 25)
						continue;
					Model.Comments.Add(new ProfileCommentRecord(item, false));
				}				
			}
			Model.IsWorking = false;
		}
	}
}
