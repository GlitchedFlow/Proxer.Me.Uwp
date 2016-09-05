using System;
using Proxer.Me.Controls.Converters;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.Core
{
	public class StylePalette : Notifier
	{
		static StylePalette()
		{
			Instance = new StylePalette();
		}

		private static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

		public static StylePalette Instance { get; private set; }

		private bool isCustomStyleActive = false;

		#region Properties

		private SolidColorBrush _background;
		private SolidColorBrush _foreground;
		private SolidColorBrush _borderBrush;
		private SolidColorBrush _separator;
		private SolidColorBrush _activeBackground;
		private SolidColorBrush _activeForeground;
		private SolidColorBrush _activeBorderBrush;
		private SolidColorBrush _hoverBackground;
		private SolidColorBrush _hoverForeground;
		private SolidColorBrush _hoverBorderBrush;
		private SolidColorBrush _clickedBackground;
		private SolidColorBrush _clickedForeground;
		private SolidColorBrush _clickedBorderBrush;
		private SolidColorBrush _pageBackground;
		private SolidColorBrush _pageForeground;
		private SolidColorBrush _disabledBackground;
		private SolidColorBrush _disabledForeground;
		private SolidColorBrush _disabledBorderBrush;

		public SolidColorBrush Background
		{
			get { return _background; }
			set
			{
				_background = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(Background)] = _background.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush Foreground
		{
			get { return _foreground; }
			set
			{
				_foreground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(Foreground)] = _foreground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush BorderBrush
		{
			get { return _borderBrush; }
			set
			{
				_borderBrush = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(BorderBrush)] = _borderBrush.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush Separator
		{
			get { return _separator; }
			set
			{
				_separator = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(Separator)] = _separator.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush ActiveBackground
		{
			get { return _activeBackground; }
			set
			{
				_activeBackground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(ActiveBackground)] = _activeBackground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush ActiveForeground
		{
			get { return _activeForeground; }
			set
			{
				_activeForeground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(ActiveForeground)] = _activeForeground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush ActiveBorderBrush
		{
			get { return _activeBorderBrush; }
			set
			{
				_activeBorderBrush = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(ActiveBorderBrush)] = _activeBorderBrush.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush HoverBackground
		{
			get { return _hoverBackground; }
			set
			{
				_hoverBackground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(HoverBackground)] = _hoverBackground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush HoverForeground
		{
			get { return _hoverForeground; }
			set
			{
				_hoverForeground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(HoverForeground)] = _hoverForeground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush HoverBorderBrush
		{
			get { return _hoverBorderBrush; }
			set
			{
				_hoverBorderBrush = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(HoverBorderBrush)] = _hoverBorderBrush.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush ClickedBackground
		{
			get { return _clickedBackground; }
			set
			{
				_clickedBackground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(ClickedBackground)] = _clickedBackground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush ClickedForeground
		{
			get { return _clickedForeground; }
			set
			{
				_clickedForeground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(ClickedForeground)] = _clickedForeground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush ClickedBorderBrush
		{
			get { return _clickedBorderBrush; }
			set
			{
				_clickedBorderBrush = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(ClickedBorderBrush)] = _clickedBorderBrush.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush PageBackground
		{
			get { return _pageBackground; }
			set
			{
				_pageBackground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(PageBackground)] = _pageBackground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush PageForeground
		{
			get { return _pageForeground; }
			set
			{
				_pageForeground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(PageForeground)] = _pageForeground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush DisabledBackground
		{
			get { return _disabledBackground; }
			set
			{
				_disabledBackground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(DisabledBackground)] = _disabledBackground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush DisabledForeground
		{
			get { return _disabledForeground; }
			set
			{
				_disabledForeground = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(DisabledForeground)] = _disabledForeground.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush DisabledBorderBrush
		{
			get { return _disabledBorderBrush; }
			set
			{
				_disabledBorderBrush = value;
				if (isCustomStyleActive)
					localSettings.Values[nameof(DisabledBorderBrush)] = _disabledBorderBrush.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		#endregion Properties

		public void SetStyleGray()
		{
			isCustomStyleActive = false;
			Background = new SolidColorBrush(Color.FromArgb(255, 108, 108, 108));
			Foreground = new SolidColorBrush(Color.FromArgb(255, 196, 196, 196));
			BorderBrush = new SolidColorBrush(Color.FromArgb(255, 139, 139, 139));
			Separator = new SolidColorBrush(Color.FromArgb(255, 163, 163, 163));
			ActiveBackground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			ActiveForeground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			ActiveBorderBrush = new SolidColorBrush(Color.FromArgb(255, 14, 175, 245));
			HoverBackground = new SolidColorBrush(Color.FromArgb(255, 112, 112, 112));
			HoverForeground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			HoverBorderBrush = new SolidColorBrush(Color.FromArgb(255, 146, 146, 146));
			ClickedBackground = new SolidColorBrush(Color.FromArgb(255, 46, 46, 46));
			ClickedForeground = new SolidColorBrush(Color.FromArgb(255, 119, 119, 119));
			ClickedBorderBrush = new SolidColorBrush(Color.FromArgb(255, 20, 20, 20));
			PageBackground = new SolidColorBrush(Color.FromArgb(255, 72, 72, 72));
			PageForeground = new SolidColorBrush(Color.FromArgb(255, 215, 215, 215));
			DisabledBackground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
			DisabledBorderBrush = new SolidColorBrush(Color.FromArgb(255, 40, 40, 40));
			DisabledForeground = new SolidColorBrush(Color.FromArgb(255, 60, 60, 60));
		}

		public void SetStyleDark()
		{
			isCustomStyleActive = false;
			Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			Separator = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			ActiveBackground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
			ActiveForeground = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180));
			ActiveBorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
			HoverBackground = new SolidColorBrush(Color.FromArgb(255, 60, 60, 60));
			HoverForeground = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
			HoverBorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
			ClickedBackground = new SolidColorBrush(Color.FromArgb(255, 15, 15, 15));
			ClickedForeground = new SolidColorBrush(Color.FromArgb(255, 160, 160, 160));
			ClickedBorderBrush = new SolidColorBrush(Color.FromArgb(255, 5, 5, 5));
			PageBackground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			PageForeground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			DisabledBackground = new SolidColorBrush(Color.FromArgb(255, 5, 5, 5));
			DisabledBorderBrush = new SolidColorBrush(Color.FromArgb(255, 10, 10, 10));
			DisabledForeground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
		}

		public void SetStyleBlue()
		{
			isCustomStyleActive = false;
			Background = new SolidColorBrush(Color.FromArgb(255, 32, 165, 201));
			Foreground = new SolidColorBrush(Color.FromArgb(255, 191, 229, 224));
			BorderBrush = new SolidColorBrush(Color.FromArgb(255, 14, 198, 234));
			Separator = new SolidColorBrush(Color.FromArgb(255, 191, 229, 224));
			ActiveBackground = new SolidColorBrush(Color.FromArgb(255, 5, 84, 127));
			ActiveForeground = new SolidColorBrush(Color.FromArgb(255, 170, 200, 251));
			ActiveBorderBrush = new SolidColorBrush(Color.FromArgb(255, 7, 142, 120));
			HoverBackground = new SolidColorBrush(Color.FromArgb(255, 68, 111, 205));
			HoverForeground = new SolidColorBrush(Color.FromArgb(255, 2, 72, 20));
			HoverBorderBrush = new SolidColorBrush(Color.FromArgb(255, 17, 88, 93));
			ClickedBackground = new SolidColorBrush(Color.FromArgb(255, 4, 40, 70));
			ClickedForeground = new SolidColorBrush(Color.FromArgb(255, 29, 87, 188));
			ClickedBorderBrush = new SolidColorBrush(Color.FromArgb(255, 55, 115, 141));
			PageBackground = new SolidColorBrush(Color.FromArgb(255, 67, 109, 130));
			PageForeground = new SolidColorBrush(Color.FromArgb(255, 191, 229, 224));
			DisabledBackground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
			DisabledBorderBrush = new SolidColorBrush(Color.FromArgb(255, 40, 40, 40));
			DisabledForeground = new SolidColorBrush(Color.FromArgb(255, 60, 60, 60));
		}

		public void SetStyleSummer()
		{
			isCustomStyleActive = false;
			Background = new SolidColorBrush(Color.FromArgb(255, 108, 108, 108));
			Foreground = new SolidColorBrush(Color.FromArgb(255, 196, 196, 196));
			BorderBrush = new SolidColorBrush(Color.FromArgb(255, 139, 139, 139));
			Separator = new SolidColorBrush(Color.FromArgb(255, 163, 163, 163));
			ActiveBackground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			ActiveForeground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			ActiveBorderBrush = new SolidColorBrush(Color.FromArgb(255, 14, 175, 245));
			HoverBackground = new SolidColorBrush(Color.FromArgb(255, 112, 112, 112));
			HoverForeground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			HoverBorderBrush = new SolidColorBrush(Color.FromArgb(255, 146, 146, 146));
			ClickedBackground = new SolidColorBrush(Color.FromArgb(255, 46, 46, 46));
			ClickedForeground = new SolidColorBrush(Color.FromArgb(255, 119, 119, 119));
			ClickedBorderBrush = new SolidColorBrush(Color.FromArgb(255, 20, 20, 20));
			PageBackground = new SolidColorBrush(Color.FromArgb(255, 72, 72, 72));
			PageForeground = new SolidColorBrush(Color.FromArgb(255, 215, 215, 215));
			DisabledBackground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
			DisabledBorderBrush = new SolidColorBrush(Color.FromArgb(255, 40, 40, 40));
			DisabledForeground = new SolidColorBrush(Color.FromArgb(255, 60, 60, 60));
		}

		public void SetStyleCustom()
		{
			isCustomStyleActive = true;
			var background = localSettings.Values[nameof(Background)];
			if (background != null)
				Background = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(background.ToString()));
			var foreground = localSettings.Values[nameof(Foreground)];
			if (foreground != null)
				Foreground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(foreground.ToString()));
			var borderBrush = localSettings.Values[nameof(BorderBrush)];
			if (borderBrush != null)
				BorderBrush = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(borderBrush.ToString()));
			var separator = localSettings.Values[nameof(Separator)];
			if (separator != null)
				Separator = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(separator.ToString()));
			var activeBG = localSettings.Values[nameof(ActiveBackground)];
			if (activeBG != null)
				ActiveBackground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(activeBG.ToString()));
			var activeFG = localSettings.Values[nameof(ActiveForeground)];
			if (activeFG != null)
				ActiveForeground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(activeFG.ToString()));
			var activeBB = localSettings.Values[nameof(ActiveBorderBrush)];
			if (activeBB != null)
				ActiveBorderBrush = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(activeBB.ToString()));
			var hoverBG = localSettings.Values[nameof(HoverBackground)];
			if (hoverBG != null)
				HoverBackground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(hoverBG.ToString()));
			var hoverFG = localSettings.Values[nameof(HoverForeground)];
			if (hoverFG != null)
				HoverForeground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(hoverFG.ToString()));
			var hoverBB = localSettings.Values[nameof(HoverBorderBrush)];
			if (hoverBB != null)
				HoverBorderBrush = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(hoverBB.ToString()));
			var clickedBG = localSettings.Values[nameof(ClickedBackground)];
			if (clickedBG != null)
				ClickedBackground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(clickedBG.ToString()));
			var clickedFG = localSettings.Values[nameof(ClickedForeground)];
			if (clickedFG != null)
				ClickedForeground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(clickedFG.ToString()));
			var clickedBB = localSettings.Values[nameof(ClickedBorderBrush)];
			if (clickedBB != null)
				ClickedBorderBrush = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(clickedBB.ToString()));
			var pageBG = localSettings.Values[nameof(PageBackground)];
			if (pageBG != null)
				PageBackground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(pageBG.ToString()));
			var pageFG = localSettings.Values[nameof(PageForeground)];
			if (pageFG != null)
				PageForeground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(pageFG.ToString()));
			var disabledBG = localSettings.Values[nameof(DisabledBackground)];
			if (disabledBG != null)
				DisabledBackground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(disabledBG.ToString()));
			var disabledFG = localSettings.Values[nameof(DisabledForeground)];
			if (disabledFG != null)
				DisabledForeground = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(disabledFG.ToString()));
			var disabledBB = localSettings.Values[nameof(DisabledBorderBrush)];
			if (disabledBB != null)
				DisabledBorderBrush = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(disabledBB.ToString()));
		}

		public void SetStyleDarkOrange()
		{
			isCustomStyleActive = false;
			Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			Separator = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			ActiveBackground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
			ActiveForeground = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180));
			ActiveBorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			HoverBackground = new SolidColorBrush(Color.FromArgb(255, 60, 60, 60));
			HoverForeground = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
			HoverBorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
			ClickedBackground = new SolidColorBrush(Color.FromArgb(255, 15, 15, 15));
			ClickedForeground = new SolidColorBrush(Color.FromArgb(255, 160, 160, 160));
			ClickedBorderBrush = new SolidColorBrush(Color.FromArgb(255, 5, 5, 5));
			PageBackground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			PageForeground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
			DisabledBackground = new SolidColorBrush(Color.FromArgb(255, 5, 5, 5));
			DisabledBorderBrush = new SolidColorBrush(Color.FromArgb(255, 10, 10, 10));
			DisabledForeground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));
		}
	}
}