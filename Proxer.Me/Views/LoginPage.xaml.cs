using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
	public sealed partial class LoginPage : Page
	{
		public LoginPage()
		{
			this.InitializeComponent();
			DataContext = LoginViewModel.Instance;
			if (LoginViewModel.Instance.Model.ExecuteAutoLogin)
			{
				if (LoginViewModel.Instance.Model.Settings.UserToken != null)
				{
					LoginViewModel.Instance.Model.UserLoggedIn = true;
					LoginViewModel.Instance.Login.Execute(null);
				}
				else
				{
					LoginViewModel.Instance.Model.UserLoggedIn = false;
				}
			}
		}

		private void loginPassword_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			if (e.Key == VirtualKey.Enter)
			{
				if (LoginViewModel.Instance.Login.CanExecute(null))
				{
					LoginViewModel.Instance.Login.Execute(null);
				}
			}
		}
	}
}