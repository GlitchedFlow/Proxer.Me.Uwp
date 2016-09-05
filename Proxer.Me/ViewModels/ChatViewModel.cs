using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Models;

namespace Proxer.Me.ViewModels
{
	public class ChatViewModel : ViewModel<ChatModel>
	{
		static ChatViewModel()
		{
			Instance = new ChatViewModel();
		}

		public ChatViewModel() : base(new ChatModel())
		{
		}

		public static ChatViewModel Instance { get; private set; }
	}
}
