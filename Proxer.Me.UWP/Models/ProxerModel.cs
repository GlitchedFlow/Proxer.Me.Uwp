using Proxer.Me.Resources;
using Proxer.Me.Support.Api.Data.Media;
using Proxer.Me.UWP.ViewModels;
using Template10.Mvvm;
using Windows.UI.Xaml;

namespace Proxer.Me.UWP.Models
{
	public class ProxerModel : BindableBase
	{
		private ShellModel shellModel;

		public ShellModel ShellModel
		{
			get
			{
				if (shellModel == null)
					shellModel = ((ShellViewModel)Application.Current.Resources[typeof(ShellViewModel).Name])?.Model;
				return shellModel;
			}
		}

		public SettingsModel SettingsModel
		{
			get
			{
				if (settingsModel == null)
					settingsModel = ((SettingsViewModel)Application.Current.Resources[typeof(SettingsViewModel).Name])?.Model;
				return settingsModel;
			}
		}

		public RandomHeader Header
		{
			get { return header; }
			set { Set(ref header, value); }
		}

		private SettingsModel settingsModel;

		private RandomHeader header;
	}
}