using Template10.Mvvm;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.Resources
{
	public sealed class StyleProvider : BindableBase
	{
		#region Public Properties

		public SolidColorBrush ActiveBackground
		{
			get { return _ActiveBackground; }
			set { Set(ref _ActiveBackground, value); }
		}

		public SolidColorBrush ActiveBorderBrush
		{
			get { return _ActiveBorderBrush; }
			set { Set(ref _ActiveBorderBrush, value); }
		}

		public SolidColorBrush ActiveForeground
		{
			get { return _ActiveForeground; }
			set { Set(ref _ActiveForeground, value); }
		}

		public SolidColorBrush Background
		{
			get { return _Background; }
			set { Set(ref _Background, value); }
		}

		public SolidColorBrush BorderBrush
		{
			get { return _BorderBrush; }
			set { Set(ref _BorderBrush, value); }
		}

		public SolidColorBrush ClickedBackground
		{
			get { return _ClickedBackground; }
			set { Set(ref _ClickedBackground, value); }
		}

		public SolidColorBrush ClickedBorderBrush
		{
			get { return _ClickedBorderBrush; }
			set { Set(ref _ClickedBorderBrush, value); }
		}

		public SolidColorBrush ClickedForeground
		{
			get { return _ClickedForeground; }
			set { Set(ref _ClickedForeground, value); }
		}

		public SolidColorBrush ContentBackground
		{
			get { return _ContentBackground; }
			set { Set(ref _ContentBackground, value); }
		}

		public SolidColorBrush ContentForeground
		{
			get { return _ContentForeground; }
			set { Set(ref _ContentForeground, value); }
		}

		public SolidColorBrush DisabledBackground
		{
			get { return _DisabledBackground; }
			set { Set(ref _DisabledBackground, value); }
		}

		public SolidColorBrush DisabledBorderBrush
		{
			get { return _DisabledBorderBrush; }
			set { Set(ref _DisabledBorderBrush, value); }
		}

		public SolidColorBrush DisabledForeground
		{
			get { return _DisabledForeground; }
			set { Set(ref _DisabledForeground, value); }
		}

		public SolidColorBrush FocusedBackground
		{
			get { return _FocusedBackground; }
			set { Set(ref _FocusedBackground, value); }
		}

		public SolidColorBrush FocusedBorderBrush
		{
			get { return _FocusedBorderBrush; }
			set { Set(ref _FocusedBorderBrush, value); }
		}

		public SolidColorBrush FocusedForeground
		{
			get { return _FocusedForeground; }
			set { Set(ref _FocusedForeground, value); }
		}

		public SolidColorBrush Foreground
		{
			get { return _Foreground; }
			set { Set(ref _Foreground, value); }
		}

		public SolidColorBrush HoverBackground
		{
			get { return _HoverBackground; }
			set { Set(ref _HoverBackground, value); }
		}

		public SolidColorBrush HoverBorderBrush
		{
			get { return _HoverBorderBrush; }
			set { Set(ref _HoverBorderBrush, value); }
		}

		public SolidColorBrush HoverForeground
		{
			get { return _HoverForeground; }
			set { Set(ref _HoverForeground, value); }
		}

		public SolidColorBrush Separator
		{
			get { return _Separator; }
			set { Set(ref _Separator, value); }
		}

		#endregion Public Properties

		#region Private Fields

		//BG:FF1A1A1A
		//FG:White
		//Accent:Firebrick

		private SolidColorBrush _ActiveBackground = new SolidColorBrush(Color.FromArgb(255, 56, 56, 56));
		private SolidColorBrush _ActiveBorderBrush = new SolidColorBrush(Colors.Firebrick);
		private SolidColorBrush _ActiveForeground = new SolidColorBrush(Colors.White);
		private SolidColorBrush _Background = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
		private SolidColorBrush _BorderBrush = new SolidColorBrush(Color.FromArgb(255, 56, 56, 56));
		private SolidColorBrush _ClickedBackground = new SolidColorBrush(Color.FromArgb(255, 18, 18, 18));
		private SolidColorBrush _ClickedBorderBrush = new SolidColorBrush(Color.FromArgb(255, 69, 69, 69));
		private SolidColorBrush _ClickedForeground = new SolidColorBrush(Color.FromArgb(255, 230, 230, 230));
		private SolidColorBrush _ContentBackground = new SolidColorBrush(Color.FromArgb(255, 26, 26, 26));
		private SolidColorBrush _ContentForeground = new SolidColorBrush(Colors.White);
		private SolidColorBrush _DisabledBackground = new SolidColorBrush(Color.FromArgb(255, 29, 29, 29));
		private SolidColorBrush _DisabledBorderBrush = new SolidColorBrush(Color.FromArgb(255, 35, 35, 35));
		private SolidColorBrush _DisabledForeground = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));
		private SolidColorBrush _FocusedBackground = new SolidColorBrush(Color.FromArgb(255, 56, 56, 56));
		private SolidColorBrush _FocusedBorderBrush = new SolidColorBrush(Colors.Firebrick);
		private SolidColorBrush _FocusedForeground = new SolidColorBrush(Colors.White);
		private SolidColorBrush _Foreground = new SolidColorBrush(Colors.White);
		private SolidColorBrush _HoverBackground = new SolidColorBrush(Color.FromArgb(255, 93, 93, 93));
		private SolidColorBrush _HoverBorderBrush = new SolidColorBrush(Color.FromArgb(255, 152, 38, 35));
		private SolidColorBrush _HoverForeground = new SolidColorBrush(Color.FromArgb(255, 240, 240, 240));
		private SolidColorBrush _Separator = new SolidColorBrush(Colors.Firebrick);

		#endregion Private Fields
	}
}