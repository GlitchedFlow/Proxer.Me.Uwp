using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
	public sealed partial class EntryPage : Page
	{
		public EntryPage()
		{
			this.InitializeComponent();
			DataContext = EntryViewModel.Instance;
			EntryViewModel.Instance.Model.CurrentEpisodePage = 0;
			EntryViewModel.Instance.Model.CurrentCommentPage = 0;
			EntryViewModel.Instance.Model.SelectedContent = 0;
			EntryViewModel.Instance.Model.SelectedInfo = 0;
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

		private void entriesList_ItemClick(object sender, ItemClickEventArgs e)
		{
			EntryViewModel.Instance.OpenEntry.Execute((e.ClickedItem as RelationRecord).Data.ID);
		}
	}
}