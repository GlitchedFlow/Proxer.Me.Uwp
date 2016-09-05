using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxAPI;

namespace Proxer.Me.ViewModels
{
	public class MessengerViewModel : ViewModel<MessengerModel>
	{
		static MessengerViewModel()
		{
			Instance = new MessengerViewModel();
		}

		public static MessengerViewModel Instance { get; private set; }

		public MessengerViewModel() : base(new MessengerModel())
		{
			
		}

		public async void getChats()
		{
			var chats = await MessengerAPI.GetConferences();
			if (chats.Error)
			{
				ErrorHandler.ShowError(chats.Code);
			}
			else
			{

			}
		}

		public override void RefreshPageContent()
		{
			base.RefreshPageContent();
			getChats();
		}
	}
}
