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

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace Proxer.Me.Views
{
	/// <summary>
	/// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert
	/// werden kann.
	/// </summary>
	public sealed partial class NewsPage : Page
	{
		public NewsPage()
		{
			this.InitializeComponent();
			DataContext = NewsViewModel.Instance;
		}

		private async void newsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var newsRecord = (sender as ListView).SelectedItem as NewsRecord;
			if (newsRecord != null)
			{
				string uriToLaunch = $"http://proxer.me/forum/{newsRecord.CategoryID}/{newsRecord.ThreadID}";
				var uri = new Uri(uriToLaunch);

				var success = await Windows.System.Launcher.LaunchUriAsync(uri);
			}
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
	}
}