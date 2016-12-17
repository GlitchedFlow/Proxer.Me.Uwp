using System;
using System.Collections.Generic;
using Proxer.Me.Controls;
using Proxer.Me.Resources;
using Proxer.Me.Support.Enums.Data;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.UWP.Models
{
	public class SettingsModel : ProxerModel
	{
		#region Public Properties

		public SolidColorBrush HighHeatColor
		{
			get { return _highHeatColor; }
			set { Set(ref _highHeatColor, value); }
		}

		public int ListSort
		{
			get { return _listSort; }
			set { Set(ref _listSort, value); }
		}

		public SolidColorBrush LowHeatColor
		{
			get { return _lowHeatColor; }
			set { Set(ref _lowHeatColor, value); }
		}

		public SolidColorBrush MiddleHeatColor
		{
			get { return _middleHeatColor; }
			set { Set(ref _middleHeatColor, value); }
		}

		public bool OpenNewsInBrowser
		{
			get { return _openNewsInBrowser; }
			set { Set(ref _openNewsInBrowser, value); }
		}

		public RatingStyle RatingStyle
		{
			get { return _ratingStyle; }
			set { Set(ref _ratingStyle, value); }
		}

		public double RecommendationValue
		{
			get { return _recommendationValue; }
			set
			{
				if (Set(ref _recommendationValue, value))
					ConverterDataProvider.RecommendationValue = value;
			}
		}

		public bool ShowHeader
		{
			get { return showHeader; }
			set { Set(ref showHeader, value); }
		}

		public bool ShowLatestUpdates
		{
			get { return _showLatestUpdates; }
			set { Set(ref _showLatestUpdates, value); }
		}

		public bool ShowNewsImages
		{
			get { return showNewsImages; }
			set { Set(ref showNewsImages, value); }
		}

		public Support.Enums.Settings.Style Style
		{
			get { return _style; }
			set { Set(ref _style, value); }
		}

		public bool SyncSettings
		{
			get { return _syncSettings; }
			set { Set(ref _syncSettings, value); }
		}

		public bool UseLongReader
		{
			get { return _useLongReader; }
			set { Set(ref _useLongReader, value); }
		}

		public bool ShowEntriesInList
		{
			get { return showEntriesInList; }
			set { Set(ref showEntriesInList, value); }
		}

		public bool GridExpanderUp
		{
			get { return gridExpanderUp; }
			set { Set(ref gridExpanderUp, value); }
		}

		public VerticalAlignment GridExpanderPosition
		{
			get { return gridExpanderPosition; }
			set { Set(ref gridExpanderPosition, value); }
		}

		public string GridExpanderPositionViewProperty
		{
			get { return GridExpanderPosition.ToString(); }
			set
			{
				GridExpanderPosition = (VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), value.ToString());
			}
		}

		public StyleProvider StyleProvider
		{
			get
			{
				if (styleProvider == null)
					styleProvider = ((StyleProvider)Application.Current.Resources[typeof(StyleProvider).Name]);
				return styleProvider;
			}
		}

		public bool GridItemsOpen
		{
			get { return gridItemsOpen; }
			set { Set(ref gridItemsOpen, value); }
		}

		#endregion Public Properties

		#region Private Fields

		private SolidColorBrush _highHeatColor = new SolidColorBrush(Colors.Red);
		private int _listSort = 1;
		private SolidColorBrush _lowHeatColor = new SolidColorBrush(Colors.Blue);
		private SolidColorBrush _middleHeatColor = new SolidColorBrush(Colors.Violet);
		private bool _openNewsInBrowser = true;
		private RatingStyle _ratingStyle = RatingStyle.StarsProgress;
		private double _recommendationValue;
		private bool _showLatestUpdates = false;
		private Support.Enums.Settings.Style _style = Support.Enums.Settings.Style.Gray;
		private bool _syncSettings;
		private bool _useLongReader = false;
		private bool showHeader = true;
		private bool showNewsImages;
		private bool showEntriesInList = false;
		private bool gridExpanderUp = true;
		private VerticalAlignment gridExpanderPosition = VerticalAlignment.Bottom;
		private bool gridItemsOpen = true;
		private StyleProvider styleProvider;

		#endregion Private Fields

		#region Public Constructors

		public SettingsModel()
		{
			RecommendationValue = 8.5;
		}

		#endregion Public Constructors

		#region UIHelper

		public List<RatingStyle> RatingStyleSource
		{
			get
			{
				if (ratingStyleSource == null)
				{
					string[] names = Enum.GetNames(typeof(RatingStyle));
					ratingStyleSource = new List<RatingStyle>();
					foreach (var name in names)
					{
						ratingStyleSource.Add((RatingStyle)Enum.Parse(typeof(RatingStyle), name));
					}
				}
				return ratingStyleSource;
			}
		}

		public List<Support.Enums.Settings.Style> StyleSource
		{
			get
			{
				if (styleSource == null)
				{
					string[] names = Enum.GetNames(typeof(Support.Enums.Settings.Style));
					styleSource = new List<Support.Enums.Settings.Style>();
					foreach (var name in names)
					{
						styleSource.Add((Support.Enums.Settings.Style)Enum.Parse(typeof(Support.Enums.Settings.Style), name));
					}
				}
				return styleSource;
			}
		}

		public List<string> ExpanderPositionSource
		{
			get
			{
				if (expanderPositionSource == null)
				{
					string[] names = Enum.GetNames(typeof(VerticalAlignment));
					expanderPositionSource = new List<string>();
					foreach (var name in names)
					{
						expanderPositionSource.Add(name);
					}
				}
				return expanderPositionSource;
			}
		}

		private List<RatingStyle> ratingStyleSource;
		private List<Support.Enums.Settings.Style> styleSource;
		private List<string> expanderPositionSource;

		#endregion UIHelper
	}
}