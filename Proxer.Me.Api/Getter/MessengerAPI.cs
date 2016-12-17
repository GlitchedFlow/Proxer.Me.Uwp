using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.Messenger;

namespace Proxer.Me.Api.Getter
{
	public class MessengerAPI
	{
		#region Public Methods

		public static async Task<ResponseData<ConferenceInfo>> GetConferenceInfo(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerGetConferenceInfo, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var conferenceInfo = JsonConvert.DeserializeObject<ResponseData<ConferenceInfo>>(responseString);
				return conferenceInfo;
			}
			else
			{
				return new ResponseData<ConferenceInfo>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Conference>>> GetConferences(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerGetConference, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var conferences = JsonConvert.DeserializeObject<ResponseData<List<Conference>>>(responseString);
				return conferences;
			}
			else
			{
				return new ResponseData<List<Conference>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<Dictionary<string, int>>> GetConstants()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerGetConstants, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var randomHeader = JsonConvert.DeserializeObject<ResponseData<Dictionary<string, int>>>(responseString);
				return randomHeader;
			}
			else
			{
				return new ResponseData<Dictionary<string, int>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Message>>> GetMessages(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerGetMessages, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var messages = JsonConvert.DeserializeObject<ResponseData<List<Message>>>(responseString);
				return messages;
			}
			else
			{
				return new ResponseData<List<Message>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<UserInfo>> GetUserInfo(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerGetUserInfo, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var conferenceInfo = JsonConvert.DeserializeObject<ResponseData<UserInfo>>(responseString);
				return conferenceInfo;
			}
			else
			{
				return new ResponseData<UserInfo>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<int>> NewConference(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerNewConference, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var newConference = JsonConvert.DeserializeObject<ResponseData<int>>(responseString);
				return newConference;
			}
			else
			{
				return new ResponseData<int>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<int>> NewConferenceGroup(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerNewConferenceGroup, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var newConferenceGroup = JsonConvert.DeserializeObject<ResponseData<int>>(responseString);
				return newConferenceGroup;
			}
			else
			{
				return new ResponseData<int>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetBlock(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerSetBlock, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setBlock = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return setBlock;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetFavour(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerSetFavour, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setFavour = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return setFavour;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetMessage(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerSetMessage, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setMessage = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return setMessage;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetReport(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerSetReport, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setReport = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return setReport;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetUnblock(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerSetUnblock, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setUnblock = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return setUnblock;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetUnfavour(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerSetUnfavour, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setUnfavour = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return setUnfavour;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetUnread(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MessengerSetUnread, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var setUnread = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return setUnread;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		#endregion Public Methods
	}
}