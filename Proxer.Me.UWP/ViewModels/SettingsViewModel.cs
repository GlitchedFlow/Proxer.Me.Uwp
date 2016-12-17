using System;
using Proxer.Me.Support.Enums.Data;
using Proxer.Me.UWP.Models;
using Template10.Mvvm;
using Windows.UI.Xaml;

namespace Proxer.Me.UWP.ViewModels
{
	public class SettingsViewModel : ProxerViewModel<SettingsModel>
	{
		Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
		public DelegateCommand SaveSettings { get; private set; }

		public DelegateCommand CancelSettings { get; private set; }

		public SettingsViewModel() : base(new SettingsModel())
		{
			loadSettings();
			SaveSettings = new DelegateCommand(ExecuteSaveSettings);
			CancelSettings = new DelegateCommand(ExecuteCancelSettings);
		}

		private void ExecuteCancelSettings()
		{
			loadSettings();
		}

		private void ExecuteSaveSettings()
		{
			localSettings.Values[nameof(Model.GridExpanderPosition)] = (int)Model.GridExpanderPosition;
			localSettings.Values[nameof(Model.GridExpanderUp)] = Model.GridExpanderUp;
			localSettings.Values[nameof(Model.GridItemsOpen)] = Model.GridItemsOpen;
			localSettings.Values[nameof(Model.ListSort)] = Model.ListSort;
			localSettings.Values[nameof(Model.OpenNewsInBrowser)] = Model.OpenNewsInBrowser;
			localSettings.Values[nameof(Model.RatingStyle)] = (int)Model.RatingStyle;
			localSettings.Values[nameof(Model.RecommendationValue)] = Model.RecommendationValue;
			localSettings.Values[nameof(Model.ShowEntriesInList)] = Model.ShowEntriesInList;
			localSettings.Values[nameof(Model.ShowHeader)] = Model.ShowHeader;
			localSettings.Values[nameof(Model.ShowLatestUpdates)] = Model.ShowLatestUpdates;
			localSettings.Values[nameof(Model.ShowNewsImages)] = Model.ShowNewsImages;
			localSettings.Values[nameof(Model.SyncSettings)] = Model.SyncSettings;
			localSettings.Values[nameof(Model.UseLongReader)] = Model.UseLongReader;
		}

		private void loadSettings()
		{
			if (localSettings.Values[nameof(Model.GridExpanderPosition)] != null)
				Model.GridExpanderPosition = (VerticalAlignment)Enum.ToObject(typeof(VerticalAlignment), (int)localSettings.Values[nameof(Model.GridExpanderPosition)]);
			if (localSettings.Values[nameof(Model.GridExpanderUp)] != null)
				Model.GridExpanderUp = (bool)localSettings.Values[nameof(Model.GridExpanderUp)];
			if (localSettings.Values[nameof(Model.GridItemsOpen)] != null)
				Model.GridItemsOpen = (bool)localSettings.Values[nameof(Model.GridItemsOpen)];
			if (localSettings.Values[nameof(Model.ListSort)] != null)
				Model.ListSort = (int)localSettings.Values[nameof(Model.ListSort)];
			if (localSettings.Values[nameof(Model.OpenNewsInBrowser)] != null)
				Model.OpenNewsInBrowser = (bool)localSettings.Values[nameof(Model.OpenNewsInBrowser)];
			if (localSettings.Values[nameof(Model.RatingStyle)] != null)
				Model.RatingStyle = (RatingStyle)Enum.ToObject(typeof(RatingStyle), (int)localSettings.Values[nameof(Model.RatingStyle)]);
			if (localSettings.Values[nameof(Model.RecommendationValue)] != null)
				Model.RecommendationValue = (double)localSettings.Values[nameof(Model.RecommendationValue)];
			if (localSettings.Values[nameof(Model.ShowEntriesInList)] != null)
				Model.ShowEntriesInList = (bool)localSettings.Values[nameof(Model.ShowEntriesInList)];
			if (localSettings.Values[nameof(Model.ShowHeader)] != null)
				Model.ShowHeader = (bool)localSettings.Values[nameof(Model.ShowHeader)];
			if (localSettings.Values[nameof(Model.ShowLatestUpdates)] != null)
				Model.ShowLatestUpdates = (bool)localSettings.Values[nameof(Model.ShowLatestUpdates)];
			if (localSettings.Values[nameof(Model.ShowNewsImages)] != null)
				Model.ShowNewsImages = (bool)localSettings.Values[nameof(Model.ShowNewsImages)];
			if (localSettings.Values[nameof(Model.SyncSettings)] != null)
				Model.SyncSettings = (bool)localSettings.Values[nameof(Model.SyncSettings)];
			if (localSettings.Values[nameof(Model.UseLongReader)] != null)
				Model.UseLongReader = (bool)localSettings.Values[nameof(Model.UseLongReader)];
		}
	}
}