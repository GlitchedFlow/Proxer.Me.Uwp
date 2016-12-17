using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.Info;
using Proxer.Me.Support.Enums.Data;

namespace Proxer.Me.Api.Getter
{
	public static class InfoAPI
	{
		#region Public Methods

		public static async Task<ResponseData<List<Comment>>> GetComments(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoComments, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var comment = JsonConvert.DeserializeObject<ResponseData<List<Comment>>>(responseString);
				return comment;
			}
			else
			{
				return new ResponseData<List<Comment>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<Entry>> GetEntry(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoEntry, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var entry = JsonConvert.DeserializeObject<ResponseData<Entry>>(responseString);
				return entry;
			}
			else
			{
				return new ResponseData<Entry>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<FullEntry>> GetFullEntry(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoFullEntry, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var entry = JsonConvert.DeserializeObject<ResponseData<FullEntry>>(responseString);
				return entry;
			}
			else
			{
				return new ResponseData<FullEntry>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<bool>> GetGate(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoGate, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var gate = JsonConvert.DeserializeObject<ResponseData<bool>>(responseString);
				return gate;
			}
			else
			{
				return new ResponseData<bool>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Group>>> GetGroups(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoGroups, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var group = JsonConvert.DeserializeObject<ResponseData<List<Group>>>(responseString);
				return group;
			}
			else
			{
				return new ResponseData<List<Group>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Language>>> GetLang(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoLang, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var lang = JsonConvert.DeserializeObject<ResponseData<List<Language>>>(responseString);
				return lang;
			}
			else
			{
				return new ResponseData<List<Language>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<ListInfo>> GetListInfo(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoListInfo, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var listInfo = JsonConvert.DeserializeObject<ResponseData<ListInfo>>(responseString);
				return listInfo;
			}
			else
			{
				return new ResponseData<ListInfo>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<EntryName>>> GetNames(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoName, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var names = JsonConvert.DeserializeObject<ResponseData<List<EntryName>>>(responseString);
				return names;
			}
			else
			{
				return new ResponseData<List<EntryName>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Publisher>>> GetPublisher(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoPublisher, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var publisher = JsonConvert.DeserializeObject<ResponseData<List<Publisher>>>(responseString);
				return publisher;
			}
			else
			{
				return new ResponseData<List<Publisher>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Relation>>> GetRelations(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoRelations, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var relation = JsonConvert.DeserializeObject<ResponseData<List<Relation>>>(responseString);
				return relation;
			}
			else
			{
				return new ResponseData<List<Relation>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Season>>> GetSeason(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoSeason, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var season = JsonConvert.DeserializeObject<ResponseData<List<Season>>>(responseString);
				return season;
			}
			else
			{
				return new ResponseData<List<Season>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Tag>>> GetTags(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoTags, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var tags = JsonConvert.DeserializeObject<ResponseData<List<Tag>>>(responseString);
				return tags;
			}
			else
			{
				return new ResponseData<List<Tag>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetInfo(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.InfoSetInfo, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var info = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return info;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		#endregion Public Methods
	}
}