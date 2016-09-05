using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxAPI;
using Proxer.Me.ProxData.User;
using Proxer.Me.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.ViewModels
{
	public class UserControlViewModel : ViewModel<UserControlModel>
	{
		static UserControlViewModel()
		{
			Instance = new UserControlViewModel();
		}

		public static UserControlViewModel Instance { get; private set; }

		public UserControlViewModel() : base(new UserControlModel())
		{
			
		}
	}
}
