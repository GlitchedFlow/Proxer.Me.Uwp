using System;
using System.Threading.Tasks;
using Microsoft.HockeyApp;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Views;
using Template10.Common;
using Template10.Controls;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : BootStrapper
	{
		/// <summary>
		/// Initializes the singleton application object. This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			Microsoft.HockeyApp.HockeyClient.Current.Configure("4443e8080d1a456b8fb32dbf3c862595");
			InitializeComponent();
			SplashFactory = (e) => new Splash(e);
			UnhandledException += App_UnhandledException;
		}

		private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Busy.SetBusy(false);
			Info.SetInfo(true, e.Message);
		}

		public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
		{
			await NavigationService.NavigateAsync(typeof(LoginPage));
			await Task.CompletedTask;
		}

		public override async Task OnInitializeAsync(IActivatedEventArgs args)
		{
			if (Window.Current.Content as ModalDialog == null)
			{
				// create a new frame
				var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
				// create modal root
				Window.Current.Content = new ModalDialog { DisableBackButtonWhenModal = true, Content = new Shell(nav), ModalContent = new Busy(), };
			}

			await Task.CompletedTask;
		}

		/// <summary>
		/// Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">
		/// The Frame which failed navigation
		/// </param>
		/// <param name="e">
		/// Details about the navigation failure
		/// </param>
		private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// Invoked when application execution is being suspended. Application state is saved without
		/// knowing whether the application will be terminated or resumed with the contents of memory
		/// still intact.
		/// </summary>
		/// <param name="sender">
		/// The source of the suspend request.
		/// </param>
		/// <param name="e">
		/// Details about the suspend request.
		/// </param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}
	}
}