using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Models;

namespace Proxer.Me.ViewModels
{
	public class SettingsViewModel : ViewModel<SettingsModel>
	{
		static SettingsViewModel()
		{
			Instance = new SettingsViewModel();
		}

		public static SettingsViewModel Instance { get; private set; }

		public SettingsViewModel() : base(new SettingsModel())
		{
		}
	}
}
