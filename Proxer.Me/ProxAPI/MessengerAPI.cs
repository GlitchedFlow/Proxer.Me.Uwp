using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxData.Messenger;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxAPI
{
	public class MessengerAPI
	{
		private const string GetConstantsURL = "https://proxer.me/api/v1/messenger/constants";
		private const string GetConferenceURL = "https://proxer.me/api/v1/messenger/conferences";
		private const string GetConferenceInfoURL = "https://proxer.me/api/v1/messenger/conferenceinfo";
		private const string GetMessagesURL = "https://proxer.me/api/v1/messenger/messages";
		private const string NewConferenceURL = "https://proxer.me/api/v1/messenger/newconference";
		private const string NewConferenceGroupURL = "https://proxer.me/api/v1/messenger/newconferencegroup";
		private const string SetReportURL = "https://proxer.me/api/v1/messenger/report";
		private const string SetMessageURL = "https://proxer.me/api/v1/messenger/setmessage";
		private const string SetUnreadURL = "https://proxer.me/api/v1/messenger/setunread";
		private const string SetBlockURL = "https://proxer.me/api/v1/messenger/setblock";
		private const string SetUnblockURL = "https://proxer.me/api/v1/messenger/setunblock";
		private const string SetFavourURL = "https://proxer.me/api/v1/messenger/setfavour";
		private const string SetUnfavourURL = "https://proxer.me/api/v1/messenger/setunfavour";

		public static async Task<Constants> GetConstants()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(GetConstantsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var randomHeader = JsonConvert.DeserializeObject<Constants>(responseString);
				return randomHeader;
			}
			else
			{
				return new Constants() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Conferences> GetConferences(ConferenceType type = ConferenceType.Default, int page = 0)
		{
			var values = new Dictionary<string, string>
			{
				{ "type", type.ToString().ToLower() },
				{ "p", page.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(GetConferenceURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var conferences = JsonConvert.DeserializeObject<Conferences>(responseString);
				return conferences;
			}
			else
			{
				return new Conferences() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ConferenceInfo> GetConferenceInfo(int id)
		{
			var values = new Dictionary<string, string>
			{
				{ "id", id.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(GetConferenceInfoURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var conferenceInfo = JsonConvert.DeserializeObject<ConferenceInfo>(responseString);
				return conferenceInfo;
			}
			else
			{
				return new ConferenceInfo() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Messages> GetMessages(int conferenceID, int messageID)
		{
			var values = new Dictionary<string, string>
			{
				{ "conference_id", conferenceID.ToString() },
				{ "message_id", messageID.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(GetMessagesURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var messages = JsonConvert.DeserializeObject<Messages>(responseString);
				return messages;
			}
			else
			{
				return new Messages() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<NewConference> NewConference(string text, string username)
		{
			var values = new Dictionary<string, string>
			{
				{ "text", text },
				{ "username", username }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(NewConferenceURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var newConference = JsonConvert.DeserializeObject<NewConference>(responseString);
				return newConference;
			}
			else
			{
				return new NewConference() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<NewConference> NewConferenceGroup(string[] usernames, string topic, string text = "")
		{
			var values = new Dictionary<string, string>();
			var users = "[";
			foreach (var item in usernames)
			{
				users += $"\"{item}\",";
			}
			users += "]";
			if (users.Contains(','))
				users = users.Remove(users.LastIndexOf(','), 1);
			values.Add("users", users);
			values.Add("topic", topic);
			if (!string.IsNullOrWhiteSpace(text))
				values.Add("text", text);

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(NewConferenceGroupURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var newConferenceGroup = JsonConvert.DeserializeObject<NewConference>(responseString);
				return newConferenceGroup;
			}
			else
			{
				return new NewConference() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<SetVariable> SetReport(string text, int conferenceID)
		{
			var values = new Dictionary<string, string>
			{
				{ "text", text },
				{ "conference_ID", conferenceID.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetReportURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setReport = JsonConvert.DeserializeObject<SetVariable>(responseString);
				return setReport;
			}
			else
			{
				return new SetVariable() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<SetVariable> SetMessage(string text, int conferenceID)
		{
			var values = new Dictionary<string, string>
			{
				{ "conference_ID", conferenceID.ToString() },
				{ "text", text }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetMessageURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setMessage = JsonConvert.DeserializeObject<SetVariable>(responseString);
				return setMessage;
			}
			else
			{
				return new SetVariable() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<SetVariable> SetUnread(int conferenceID)
		{
			var values = new Dictionary<string, string>
			{
				{ "conference_ID", conferenceID.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetUnreadURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setUnread = JsonConvert.DeserializeObject<SetVariable>(responseString);
				return setUnread;
			}
			else
			{
				return new SetVariable() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<SetVariable> SetBlock(int conferenceID)
		{
			var values = new Dictionary<string, string>
			{
				{ "conference_ID", conferenceID.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetBlockURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setBlock = JsonConvert.DeserializeObject<SetVariable>(responseString);
				return setBlock;
			}
			else
			{
				return new SetVariable() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<SetVariable> SetUnblock(int conferenceID)
		{
			var values = new Dictionary<string, string>
			{
				{ "conference_ID", conferenceID.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetUnblockURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setUnblock = JsonConvert.DeserializeObject<SetVariable>(responseString);
				return setUnblock;
			}
			else
			{
				return new SetVariable() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<SetVariable> SetFavour(int conferenceID)
		{
			var values = new Dictionary<string, string>
			{
				{ "conference_ID", conferenceID.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetFavourURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setFavour = JsonConvert.DeserializeObject<SetVariable>(responseString);
				return setFavour;
			}
			else
			{
				return new SetVariable() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<SetVariable> SetUnfavour(int conferenceID)
		{
			var values = new Dictionary<string, string>
			{
				{ "conference_ID", conferenceID.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetUnfavourURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setUnfavour = JsonConvert.DeserializeObject<SetVariable>(responseString);
				return setUnfavour;
			}
			else
			{
				return new SetVariable() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}
