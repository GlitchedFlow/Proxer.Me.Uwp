using Proxer.Me.Support.Api.Data.Messenger;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Controls.Selectors
{
	public class MessageTemplateSelector : DataTemplateSelector
	{
		public DataTemplate RecievedMessage { get; set; }

		public DataTemplate SendMessage { get; set; }

		public DataTemplate Info { get; set; }

		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
			Message message = (Message)item;
			if (message != null)
			{
				if (message.IsInfo)
					return Info;
				else if (message.IsSendByMe)
					return SendMessage;
				else
					return RecievedMessage;
			}
			return SendMessage;
		}
	}
}