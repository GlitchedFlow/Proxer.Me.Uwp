using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.List;

namespace Proxer.Me.Api.Getter
{
	public static class ListAPI
	{
		#region Public Methods

		public static async Task<ResponseData<List<EntryList>>> GetEntryList(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.ListEntryList, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var entryList = JsonConvert.DeserializeObject<ResponseData<List<EntryList>>>(responseString);
				return entryList;
			}
			else
			{
				return new ResponseData<List<EntryList>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<EntrySearch>>> GetEntrySearch(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.ListEntrySearch, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var entrySearch = JsonConvert.DeserializeObject<ResponseData<List<EntrySearch>>>(responseString);
				return entrySearch;
			}
			else
			{
				return new ResponseData<List<EntrySearch>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<TagID>> GetTagIDs(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.ListTagID, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var tagID = JsonConvert.DeserializeObject<ResponseData<TagID>>(responseString);
				return tagID;
			}
			else
			{
				return new ResponseData<TagID>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Tag>>> GetTags(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.ListTag, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var tag = JsonConvert.DeserializeObject<ResponseData<List<Tag>>>(responseString);
				return tag;
			}
			else
			{
				return new ResponseData<List<Tag>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		#endregion Public Methods
	}
}