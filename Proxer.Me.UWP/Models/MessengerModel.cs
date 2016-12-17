using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Proxer.Me.Support.Api.Data.Messenger;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.UWP.Models
{
	public class MessengerModel : PaneModel
	{
		private int maxTextLength;

		public int MaxTextLength
		{
			get { return maxTextLength; }
			set { Set(ref maxTextLength, value); }
		}

		public int MaxConferencesGet
		{
			get { return maxConferencesGet; }
			set { Set(ref maxConferencesGet, value); }
		}

		public int MaxMessagesGet
		{
			get { return maxMessagesGet; }
			set { Set(ref maxMessagesGet, value); }
		}

		public int MaxUserCount
		{
			get { return maxUserCount; }
			set { Set(ref maxUserCount, value); }
		}

		public int MaxTopicLength
		{
			get { return maxTopicLength; }
			set { Set(ref maxTopicLength, value); }
		}

		private bool hasMoreMessages;

		public bool IsUseable { get; set; }

		public ObservableCollection<Conference> ConferenceCollection
		{
			get { return conferenceCollection; }
			set { Set(ref conferenceCollection, value); }
		}

		public Conference SelectedConference
		{
			get { return selectedConference; }
			set
			{
				if (PaneDisplayMode == SplitViewDisplayMode.Overlay)
					IsPaneOpen = false;
				Set(ref selectedConference, value);
				RaisePropertyChanged(nameof(ChatSelected));
			}
		}

		public bool ChatSelected
		{
			get { return SelectedConference == null ? false : true; }
		}

		public bool LoadingChats
		{
			get { return loadingChats; }
			set { Set(ref loadingChats, value); }
		}

		public bool LoadingActiveChat
		{
			get { return loadingActiveChat; }
			set { Set(ref loadingActiveChat, value); }
		}

		public ObservableCollection<Message> MessageCollection
		{
			get { return messageCollection; }
			set { Set(ref messageCollection, value); }
		}

		public bool HasMoreMessages
		{
			get { return hasMoreMessages; }
			set { Set(ref hasMoreMessages, value); }
		}

		public string InputMessage
		{
			get { return inputMessage; }
			set { Set(ref inputMessage, value); }
		}

		public IEnumerable<IGrouping<int, Message>> GroupedMessages
		{
			get { return groupedMessages; }
			set { Set(ref groupedMessages, value); }
		}

		public bool ScrollToBottom
		{
			get { return scrollToBottom; }
			set { Set(ref scrollToBottom, value); }
		}

		private int maxConferencesGet;

		private int maxMessagesGet;

		private int maxUserCount;

		private int maxTopicLength;

		private ObservableCollection<Conference> conferenceCollection;

		private ObservableCollection<Message> messageCollection;

		private IEnumerable<IGrouping<int, Message>> groupedMessages;

		private Conference selectedConference;

		private bool loadingChats;

		private bool loadingActiveChat;

		private string inputMessage;

		private bool scrollToBottom;
	}
}