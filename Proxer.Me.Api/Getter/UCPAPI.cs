using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.UCP;

namespace Proxer.Me.Api.Getter
{
	public static class UCPAPI
	{
		#region Public Methods

		public static async Task<ResponseData<List<History>>> GetHistory(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPHistory, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var history = JsonConvert.DeserializeObject<ResponseData<List<History>>>(responseString);
				return history;
			}
			else
			{
				return new ResponseData<List<History>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<List>>> GetList(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPList, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var list = JsonConvert.DeserializeObject<ResponseData<List<List>>>(responseString);
				return list;
			}
			else
			{
				return new ResponseData<List<List>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<int>> GetListSum(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPListSum, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var listSum = JsonConvert.DeserializeObject<ResponseData<int>>(responseString);
				return listSum;
			}
			else
			{
				return new ResponseData<int>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Reminder>>> GetReminder(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPReminder, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var reminder = JsonConvert.DeserializeObject<ResponseData<List<Reminder>>>(responseString);
				return reminder;
			}
			else
			{
				return new ResponseData<List<Reminder>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<TopTen>>> GetTopTen()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPTopTen, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var topTen = JsonConvert.DeserializeObject<ResponseData<List<TopTen>>>(responseString);
				return topTen;
			}
			else
			{
				return new ResponseData<List<TopTen>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Vote>>> GetVotes()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPVote, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var votes = JsonConvert.DeserializeObject<ResponseData<List<Vote>>>(responseString);
				return votes;
			}
			else
			{
				return new ResponseData<List<Vote>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetCommentState(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPSetCommentState, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var commentState = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return commentState;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetDeleteFavorite(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPDelFavorite, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var delFavorite = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return delFavorite;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetDeleteReminder(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPDelReminder, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var delReminder = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return delReminder;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetDeleteVote(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPDelVote, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var deleteVote = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return deleteVote;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetReminder(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UCPSetReminder, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var commentState = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return commentState;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		#endregion Public Methods
	}
}