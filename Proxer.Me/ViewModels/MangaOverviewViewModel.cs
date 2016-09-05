using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxAPI;
using Proxer.Me.ProxSupport;
using Proxer.Me.Records;
using Proxer.Me.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.ViewModels
{
	public class MangaOverviewViewModel : ViewModel<MangaOverviewModel>
	{
		static MangaOverviewViewModel()
		{
			Instance = new MangaOverviewViewModel();
		}

		public static MangaOverviewViewModel Instance { get; private set; }

		public DelegateCommand RefreshList { get; private set; }

		public DelegateCommand RefreshLatest { get; private set; }

		public DelegateCommand NextPage { get; private set; }

		public DelegateCommand PreviousPage { get; private set; }

		public DelegateCommand OpenEntry { get; private set; }

		public MangaOverviewViewModel() : base(new MangaOverviewModel())
		{
			RefreshList = new DelegateCommand(ExecuteRefreshList, CanExecuteRefreshList);
			RefreshLatest = new DelegateCommand(ExecuteRefreshLatest);
			NextPage = new DelegateCommand(ExecuteNextPage, CanExecuteNextPage);
			PreviousPage = new DelegateCommand(ExecutePreviousPage, CanExecutePreviousPage);
			OpenEntry = new DelegateCommand(ExecuteOpenEntry);
			Model.PropertyChanged += Model_PropertyChanged;
		}

		private void ExecuteOpenEntry(object obj)
		{
			var frame = Window.Current.Content as Frame;
			EntryViewModel.Instance.Model.EntryID = Convert.ToInt32(obj);
			frame.Navigate(typeof(EntryPage), null);
		}

		private bool CanExecutePreviousPage(object obj)
		{
			return !Model.IsWorking && Model.CurrentPage > 0;
		}

		private void ExecutePreviousPage(object obj)
		{
			Model.IsWorking = true;
			Model.CurrentPage -= 1;
			RefreshLatest.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
			ExecuteRefreshList(null);
			Model.IsWorking = false;
			RefreshLatest.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
		}

		private bool CanExecuteNextPage(object obj)
		{
			return !Model.IsWorking && Model.HasNextPage;
		}

		private void ExecuteNextPage(object obj)
		{
			Model.IsWorking = true;
			Model.CurrentPage += 1;
			RefreshLatest.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
			ExecuteRefreshList(null);
			Model.IsWorking = false;
			RefreshLatest.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
		}

		private bool CanExecuteRefreshList(object obj)
		{
			return !Model.IsWorking;
		}

		private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(Model.SelectedLetter):
					Model.CurrentPage = 0;
					RefreshList.Execute(null);
					break;
				case nameof(Model.SelectedType):
					Model.CurrentPage = 0;
					RefreshLatest.Execute(null);
					RefreshList.Execute(null);
					break;
				default:
					break;
			}
		}

		private async void ExecuteRefreshLatest(object obj)
		{

		}

		private async void ExecuteRefreshList(object obj)
		{
			Model.IsWorking = true;
			Model.HasNextPage = false;
			RefreshList.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
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
			Medium medium = Medium.AnimeSeries;
			switch (Model.SelectedType)
			{
				case 1:
					medium = Medium.OneShot;
					break;
				case 2:
					medium = Medium.Doujin;
					break;
				case 3:
					medium = Medium.HManga;
					break;
				default:
					medium = Medium.MangaSeries;
					break;
			}
			var list = await ListAPI.GetEntryList(true, medium, false, start, Model.CurrentPage, 26);
			if (list.Error)
			{
				ErrorHandler.ShowError(list.Code);
			}
			else
			{
				Model.Data.Clear();
				if (list.Data.Count == 26)
					Model.HasNextPage = true;
				foreach (var manga in list.Data)
				{
					if (list.Data.Count == 26 && list.Data.IndexOf(manga) == 25)
					{
						continue;
					}
					Model.Data.Add(new EntryListRecord(manga));
				}
			}
			Model.IsWorking = false;
			RefreshList.RaiseCanExecuteChanged();
			PreviousPage.RaiseCanExecuteChanged();
			NextPage.RaiseCanExecuteChanged();
		}

		public override void RefreshPageContent()
		{
			base.RefreshPageContent();
			Model.CurrentPage = 0;
			RefreshLatest.Execute(null);
			RefreshList.Execute(null);
		}
	}
}
