using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Proxer.Me.UWP.UserControls
{
	public sealed partial class Splash : UserControl
	{
		public Splash(SplashScreen splashScreen)
		{
			this.InitializeComponent();
			Window.Current.SizeChanged += (s, e) => Resize(splashScreen);
			Resize(splashScreen);
		}

		private void Resize(SplashScreen splashScreen)
		{
			if (splashScreen.ImageLocation.Top == 0)
			{
				//SplashImage.Visibility = Visibility.Collapsed;
				return;
			}

			//RootCanvas.Background = null;
			root.Visibility = Visibility.Visible;
			root.Height = splashScreen.ImageLocation.Height;
			root.Width = splashScreen.ImageLocation.Width;
			//SplashImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
			//SplashImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
			//ProgressTransform.TranslateY = SplashImage.Height / 2;
		}
	}
}