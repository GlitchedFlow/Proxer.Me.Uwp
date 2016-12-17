using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.Messenger;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Template10.Common;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class MessengerViewModel : PaneViewModel<MessengerModel>
	{
		private List<Message> cache = new List<Message>();
		private bool allowChatRefresh = true;

		public DelegateCommand LoadMoreMessages { get; private set; }

		public DelegateCommand SendMessage { get; private set; }

		public MessengerViewModel() : base(new MessengerModel())
		{
			getConstants();
			Model.ConferenceCollection = new ObservableCollection<Conference>();
			Model.MessageCollection = new ObservableCollection<Message>();
			Model.PropertyChanged += Model_PropertyChanged;
			LoadMoreMessages = new DelegateCommand(ExecuteLoadMoreMessages, CanExecuteLoadMoreMessages);
			SendMessage = new DelegateCommand(ExecuteSendMessage, CanExecuteSendMessage);
		}

		private bool CanExecuteSendMessage()
		{
			return !string.IsNullOrWhiteSpace(Model.InputMessage);
		}

		private async void ExecuteSendMessage()
		{
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("conference_id", Model.SelectedConference.ID.ToString());
			postParas.Add("text", Model.InputMessage);
			ResponseData result = await MessengerAPI.SetMessage(postParas);
			if (result.Error)
				HandleException(result);
			else
			{
				allowChatRefresh = false;
				Model.MessageCollection.Clear();
				await getMessages(Model.SelectedConference.ID, read:true);
				Model.SelectedConference.LatestMessage = Model.InputMessage;
				Model.SelectedConference.Username = Model.ShellModel.GlobalUsername;
				Model.InputMessage = null;
				Conference selected = Model.SelectedConference;
				Model.ConferenceCollection.Remove(selected);
				Model.ConferenceCollection.Insert(0, selected);
				Model.SelectedConference = selected;
				allowChatRefresh = true;
				await Dispatcher.DispatchIdleAsync(new Action(() =>
				{
					Model.ScrollToBottom = false;
					Model.ScrollToBottom = true;
				}), 300);
			}
		}

		private bool CanExecuteLoadMoreMessages()
		{
			return true;
		}

		private async void ExecuteLoadMoreMessages()
		{
			await getMessages(Model.SelectedConference.ID, Model.MessageCollection[0].MessageID, true, false, true);
		}

		private async void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Model.SelectedConference))
			{
				if (!allowChatRefresh)
					return;
				Model.MessageCollection.Clear();
				Model.GroupedMessages = null;
				if (Model.SelectedConference != null)
				{
					await getMessages(Model.SelectedConference.ID, read: true);
					await Dispatcher.DispatchIdleAsync(new Action(() =>
					{
						Model.ScrollToBottom = false;
						Model.ScrollToBottom = true;
					}), 300);
					await Dispatcher.DispatchIdleAsync(new Action(() =>
					{
						int? messageID = Model.MessageCollection.Last().MessageID;
						if (messageID != null)
						{
							Model.SelectedConference.ReadCount = 0;
							Model.SelectedConference.ReadMessageID = messageID.Value;
						}
					}), 500);
				}
			}
			if (e.PropertyName == nameof(Model.InputMessage))
			{
				SendMessage.RaiseCanExecuteChanged();
			}
		}

		private async Task getMessages(int? conferenceID = null, int? messageID = null, bool read = false, bool resultIntoCache = false, bool insertAtTop = false)
		{
			if (resultIntoCache)
				cache.Clear();
			else
				Busy.SetBusy(true, "Chat wird geladen...");
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("conference_id", conferenceID != null ? conferenceID.Value.ToString() : "0");
			postParas.Add("message_id", messageID != null ? messageID.Value.ToString() : "0");
			if (read)
				postParas.Add("read", "true");
			else
				postParas.Add("read", "false");
			ResponseData<List<Message>> messages = await MessengerAPI.GetMessages(postParas);
			//messages.Data.ForEach(x => System.Diagnostics.Debug.WriteLine(x.Username + " " + x.Text));
			if (!messages.Error)
			{
				if (messages.Data.Count == Model.MaxMessagesGet)
					Model.HasMoreMessages = true;
				else
					Model.HasMoreMessages = false;
				for (int i = 0; i < messages.Data.Count; i++)
				{
					Message currentMessage = messages.Data[i];
					if (resultIntoCache)
					{
						if (!IsInfoMessage(currentMessage))
							cache.Add(currentMessage);
					}
					else
					{
						if (Model.SelectedConference != null)
							currentMessage.IsGroupMessage = Model.SelectedConference.IsGroup;
						if (currentMessage.Username == Model.ShellModel.GlobalUsername)
							currentMessage.IsSendByMe = true;
						if (IsInfoMessage(currentMessage))
							currentMessage.IsInfo = true;
						if (currentMessage.IsInfo)
						{
							await Task.Delay(300);
							await setInfoText(currentMessage);
						}
						if (i > 0)
							currentMessage.PreviousMessage = messages.Data[i - 1];
						if (insertAtTop)
							Model.MessageCollection.Insert(i, currentMessage);
						else
							Model.MessageCollection.Add(currentMessage);
					}
				}
				if (!resultIntoCache)
				{
					Model.GroupedMessages = Model.MessageCollection.GroupBy(x => TimeSpan.FromTicks(x.DateTime.Ticks).Days);
					Busy.SetBusy(false);
				}
			}
			else
			{
				HandleException(messages);
			}
		}

		private async Task setInfoText(Message currentMessage)
		{
			if (currentMessage.Action == "addUser")
			{
				ResponseData<UserInfo> info = await UserAPI.GetUserInfo(new Dictionary<string, string>() { { "uid", currentMessage.Text } });
				if (info.Error)
					currentMessage.Text = $"{currentMessage.Username} hat einen User hinzugefügt.";
				else
					currentMessage.Text = $"{currentMessage.Username} hat {info.Data.Username} hinzugefügt.";
			}
			else if (currentMessage.Action == "removeUser")
			{
				ResponseData<UserInfo> info = await UserAPI.GetUserInfo(new Dictionary<string, string>() { { "uid", currentMessage.Text } });
				if (info.Error)
					currentMessage.Text = $"{currentMessage.Username} hat einen User entfernt.";
				else
					currentMessage.Text = $"{currentMessage.Username} hat {info.Data.Username} entfernt.";
			}
			else if (currentMessage.Action == "exit")
			{
				currentMessage.Text = $"{currentMessage.Username} hat die Unterhaltung verlassen.";
			}
			else if (currentMessage.Action == "leader")
			{
				currentMessage.Text = Model.SelectedConference.Leader;
			}
			else if (currentMessage.Action == "setLeader")
			{
				ResponseData<UserInfo> info = await UserAPI.GetUserInfo(new Dictionary<string, string>() { { "uid", currentMessage.Text } });
				if (info.Error)
					currentMessage.Text = $"{currentMessage.Username} hat einem anderen User die Leader-Rechte übergeben.";
				else
					currentMessage.Text = $"{currentMessage.Username} hat {info.Data.Username} die Leader-Rechte übergeben.";
			}
			else if (currentMessage.Action == "topic")
			{
				currentMessage.Text = Model.SelectedConference.Topic;
			}
			else if (currentMessage.Action == "setTopic")
			{
				currentMessage.Text = $"{currentMessage.Username} hat den auf {currentMessage.Text} geändert.";
			}
			else
			{
				currentMessage.Text = "Pong";
			}
		}

		private bool IsInfoMessage(Message message)
		{
			return !string.IsNullOrWhiteSpace(message.Action);
		}

		private async void getConstants()
		{
			ResponseData<Dictionary<string, int>> constants = await MessengerAPI.GetConstants();
			if (!constants.Error)
			{
				Model.MaxTextLength = constants.Data["textCount"];
				Model.MaxConferencesGet = constants.Data["conferenceLimit"];
				Model.MaxMessagesGet = constants.Data["messagesLimit"];
				Model.MaxUserCount = constants.Data["userLimit"];
				Model.MaxTopicLength = constants.Data["topicCount"];
				Model.IsUseable = true;
			}
			else
			{
				Model.IsUseable = false;
			}
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			if (!Model.IsUseable)
			{
				Info.SetInfo(true, "Fehler beim Initialisieren.");
				BootStrapper.Current.NavigationService.GoBack();
			}

			Model.ConferenceCollection.Clear();

			Busy.SetBusy(true, "Chats werden abgerufen...");
			await getConferences();
			Model.LoadingChats = true;
			await getLatestMessages();
			Model.LoadingChats = false;
			Busy.SetBusy(false);
			Model.MessageCollection.Clear();

			await base.OnNavigatedToAsync(parameter, mode, state);
		}

		private async Task getLatestMessages()
		{
			foreach (var conf in Model.ConferenceCollection)
			{
				await getMessages(conf.ID, resultIntoCache: true);
				if (cache.Count > 0)
				{
					conf.LatestMessage = cache.Last().Text;
					conf.Username = cache.Last().Username;
				}
			}
		}

		private async Task getConferences()
		{
			Model.LoadingChats = true;
			bool hasMore = true;
			int currentConferncesPage = 0;
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("p", currentConferncesPage.ToString());
			ResponseData<List<Conference>> conferences = await MessengerAPI.GetConferences(postParas);
			if (!conferences.Error)
			{
				while (hasMore)
				{
					foreach (var conf in conferences.Data)
					{
						Model.ConferenceCollection.Add(conf);
					}
					if (conferences.Data.Count == Model.MaxConferencesGet)
					{
						hasMore = true;
						currentConferncesPage++;
					}
					else
					{
						hasMore = false;
					}
					if (hasMore)
					{
						await Task.Delay(200);
						postParas["p"] = currentConferncesPage.ToString();
						conferences = await MessengerAPI.GetConferences(postParas);
						if (conferences.Error)
						{
							hasMore = false;
							HandleException(conferences);
						}
					}
				}
			}
			else
			{
				HandleException(conferences);
			}
			Model.LoadingChats = false;
		}
	}
}