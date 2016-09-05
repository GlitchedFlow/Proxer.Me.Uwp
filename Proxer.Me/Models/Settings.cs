using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Controls.Converters;
using Proxer.Me.Core;
using Proxer.Me.ProxSupport;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.Models
{
	public class Settings : Notifier
	{
		static Settings()
		{
			Instance = new Settings();
			loadSettings();
		}

		private static void loadSettings()
		{
			var userToken = localSettings.Values[nameof(UserToken)];
			if (userToken != null)
				Instance.UserToken = (string)userToken;
			var showHeader = localSettings.Values[nameof(ShowHeader)];
			if (showHeader != null)
				Instance.ShowHeader = (bool)showHeader;
			var showNewsImages = localSettings.Values[nameof(ShowNewsImages)];
			if (showNewsImages != null)
				Instance.ShowNewsImages = (bool)showNewsImages;
			var style = localSettings.Values[nameof(Style)];
			if (style != null)
				Instance.Style = (Style)Enum.Parse(typeof(Style), style.ToString());
			else
				Instance.Style = Style.Gray;
			var home = localSettings.Values[nameof(Home)];
			if (home != null)
				Instance.Home = (HomePage)Enum.Parse(typeof(HomePage), home.ToString());
			var ratingStyle = localSettings.Values[nameof(RatingStyle)];
			if (ratingStyle != null)
				Instance.RatingStyle = (RatingStyle)Enum.Parse(typeof(RatingStyle), ratingStyle.ToString());
			var recommandation = localSettings.Values[nameof(RecommendationValue)];
			if (recommandation != null)
				Instance.RecommendationValue = (double)recommandation;
			var lowHeatColor = localSettings.Values[nameof(LowHeatColor)];
			if (lowHeatColor != null)
				Instance.LowHeatColor = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(lowHeatColor.ToString()));
			var highHeatColor = localSettings.Values[nameof(HighHeatColor)];
			if (highHeatColor != null)
				Instance.HighHeatColor = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(highHeatColor.ToString()));
			var middleHeatColor = localSettings.Values[nameof(MiddleHeatColor)];
			if (middleHeatColor != null)
				Instance.MiddleHeatColor = new SolidColorBrush(StringToColorConverter.Instance.GetColorFromHex(middleHeatColor.ToString()));
			var listStyle = localSettings.Values[nameof(ListStyle)];
			if (listStyle != null)
				Instance.ListStyle = (ListStyle)Enum.Parse(typeof(ListStyle), listStyle.ToString());
			var listSort = localSettings.Values[nameof(ListSort)];
			if (listSort != null)
				Instance.ListSort = (ListSort)Enum.Parse(typeof(ListSort), listSort.ToString());
			var showLatestUpdates = localSettings.Values[nameof(ShowLatestUpdates)];
			if (showLatestUpdates != null)
				Instance.ShowLatestUpdates = (bool)showLatestUpdates;
			var useLongReader = localSettings.Values[nameof(UseLongReader)];
			if (useLongReader != null)
				Instance.UseLongReader = (bool)useLongReader;
			var syncSettings = localSettings.Values[nameof(SyncSettings)];
			if (syncSettings != null)
				Instance.SyncSettings = (bool)syncSettings;
		}

		public static Settings Instance { get; private set; }

		public bool ShowHeader
		{
			get { return _showHeader; }
			set
			{
				_showHeader = value;
				localSettings.Values[nameof(ShowHeader)] = _showHeader;
				NotifyPropertyChanged();
			}
		}

		public bool ShowNewsImages
		{
			get { return _showNewsImages; }
			set
			{
				_showNewsImages = value;
				localSettings.Values[nameof(ShowNewsImages)] = _showNewsImages;
				NotifyPropertyChanged();
			}
		}

		public StylePalette StylePalette
		{
			get { return StylePalette.Instance; }
		}

		public Style Style
		{
			get { return _style; }
			set
			{
				_style = value;
				switch (_style)
				{
					case Style.Gray:
						StylePalette.SetStyleGray();
						break;

					case Style.Dark:
						StylePalette.SetStyleDark();
						break;

					case Style.DarkOrange:
						StylePalette.SetStyleDarkOrange();
						break;

					case Style.Summer:
						StylePalette.SetStyleSummer();
						break;

					case Style.Blue:
						StylePalette.SetStyleBlue();
						break;

					case Style.Custom:
						StylePalette.SetStyleCustom();
						break;
				}
				localSettings.Values[nameof(Style)] = _style.ToString();
				NotifyPropertyChanged();
			}
		}

		public HomePage Home
		{
			get { return _home; }
			set
			{
				_home = value;
				localSettings.Values[nameof(Home)] = _home.ToString();
				NotifyPropertyChanged();
			}
		}

		public RatingStyle RatingStyle
		{
			get { return _ratingStyle; }
			set
			{
				_ratingStyle = value;
				localSettings.Values[nameof(RatingStyle)] = _ratingStyle.ToString();
				NotifyPropertyChanged();
			}
		}

		public double RecommendationValue
		{
			get { return _recommendationValue; }
			set
			{
				double newValue = 0.0;
				try
				{
					newValue = Convert.ToDouble(value);
				}
				catch (Exception)
				{
					return;
				}
				if (newValue > 0.0 && newValue <= 10.0)
				{
					_recommendationValue = value;
					localSettings.Values[nameof(RecommendationValue)] = _recommendationValue;
					NotifyPropertyChanged();
				}
			}
		}

		public SolidColorBrush LowHeatColor
		{
			get { return _lowHeatColor; }
			set
			{
				_lowHeatColor = value;
				localSettings.Values[nameof(LowHeatColor)] = _lowHeatColor.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush HighHeatColor
		{
			get { return _highHeatColor; }
			set
			{
				_highHeatColor = value;
				localSettings.Values[nameof(HighHeatColor)] = _highHeatColor.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public SolidColorBrush MiddleHeatColor
		{
			get { return _middleHeatColor; }
			set
			{
				_middleHeatColor = value;
				localSettings.Values[nameof(MiddleHeatColor)] = _middleHeatColor.Color.ToString();
				NotifyPropertyChanged();
			}
		}

		public ListStyle ListStyle
		{
			get { return _listStyle; }
			set
			{
				_listStyle = value;
				localSettings.Values[nameof(ListStyle)] = _listStyle.ToString();
				NotifyPropertyChanged();
			}
		}

		public ListSort ListSort
		{
			get { return _listSort; }
			set
			{
				_listSort = value;
				localSettings.Values[nameof(ListSort)] = _listSort.ToString();
				NotifyPropertyChanged();
			}
		}

		public bool ShowLatestUpdates
		{
			get { return _showLatestUpdates; }
			set
			{
				_showLatestUpdates = value;
				localSettings.Values[nameof(ShowLatestUpdates)] = _showLatestUpdates;
				NotifyPropertyChanged();
			}
		}

		public bool UseLongReader
		{
			get { return _useLongReader; }
			set
			{
				_useLongReader = value;
				localSettings.Values[nameof(UseLongReader)] = _useLongReader;
				NotifyPropertyChanged();
			}
		}

		public string UserToken
		{
			get { return _userToken; }
			set
			{
				_userToken = value;
				localSettings.Values[nameof(UserToken)] = _userToken;
				ProxerClient.Instance.Client.DefaultRequestHeaders.Remove("proxer-api-token");
				if (_userToken != null)
					ProxerClient.Instance.Client.DefaultRequestHeaders.Add("proxer-api-token", _userToken);
			}
		}

		public bool SyncSettings
		{
			get { return _syncSettings; }
			set
			{
				_syncSettings = value;
				localSettings.Values[nameof(SyncSettings)] = _syncSettings;
				NotifyPropertyChanged();
			}
		}

		private bool _showHeader = true;

		private bool _showNewsImages = true;

		private Style _style = Style.Gray;

		private HomePage _home = HomePage.News;

		private RatingStyle _ratingStyle = RatingStyle.StarsProgress;

		private double _recommendationValue = 8.5;

		private SolidColorBrush _lowHeatColor = new SolidColorBrush(Colors.Blue);

		private SolidColorBrush _middleHeatColor = new SolidColorBrush(Colors.Violet);

		private SolidColorBrush _highHeatColor = new SolidColorBrush(Colors.Red);

		private ListStyle _listStyle = ListStyle.List;

		private ListSort _listSort = ListSort.Name;

		private bool _showLatestUpdates = false;

		private bool _useLongReader = false;

		private string _userToken;

		private bool _syncSettings;

		private static ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
	}
}