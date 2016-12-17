using System;
using Proxer.Me.Support.Api.Data.Messenger;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class IsContinousMessageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Message message = (Message)value;
			if (message != null)
			{
				if (message.PreviousMessage != null)
				{
					if (message.PreviousMessage.IsSendByMe == message.IsSendByMe)
						return Visibility.Visible;
				}
			}
			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}