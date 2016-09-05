using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Proxer.Me.Core;
using Proxer.Me.Records;
using Proxer.Me.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Proxer.Me.Views
{
	/// <summary>
	/// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert
	/// werden kann.
	/// </summary>
	public sealed partial class ProfilePage : Page
	{
		private ScrollViewer animeListScrollViewer;

		public ProfilePage()
		{
			this.InitializeComponent();
			DataContext = ProfileViewModel.Instance;
		}

		private void QuickSearch_KeyUp(object sender, KeyRoutedEventArgs e)
		{
			if (e.Key == Windows.System.VirtualKey.Space)
			{
				var textBox = sender as TextBox;
				textBox.SelectionStart = (textBox.Text += " ").Length;
			}
		}

		private void QuickSearch_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			if (e.Key == VirtualKey.Enter)
			{
				//if (NewsViewModel.Instance.Login.CanExecute(null))
				//{
				//	NewsViewModel.Instance.Login.Execute(null);
				//}
			}
		}

		private void animeList_ItemClick(object sender, ItemClickEventArgs e)
		{
			AnimeOverviewViewModel.Instance.OpenEntry.Execute((e.ClickedItem as ProfileListRecord).Data.ID);
		}

		private void mangaList_ItemClick(object sender, ItemClickEventArgs e)
		{
			MangaOverviewViewModel.Instance.OpenEntry.Execute((e.ClickedItem as ProfileListRecord).Data.ID);
		}

		private void animeTopTenList_ItemClick(object sender, ItemClickEventArgs e)
		{
			AnimeOverviewViewModel.Instance.OpenEntry.Execute((e.ClickedItem as TopTenRecord).ID);
		}

		private void mangaTopTenList_ItemClick(object sender, ItemClickEventArgs e)
		{
			MangaOverviewViewModel.Instance.OpenEntry.Execute((e.ClickedItem as TopTenRecord).ID);
		}
	}
}