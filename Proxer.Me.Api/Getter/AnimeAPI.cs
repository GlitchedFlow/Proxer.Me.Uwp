using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Anime;

namespace Proxer.Me.Api.Getter
{
	public static class AnimeAPI
	{
		#region Public Methods

		public static async Task<ResponseData<List<Stream>>> GetProxerStreams(IDictionary<string, string> postParas)
		{
			FormUrlEncodedContent content = new FormUrlEncodedContent(postParas);

			HttpResponseMessage response = await ProxerClient.Client.PostAsync(UrlCollection.AnimeProxerStreams, content);

			if (response.IsSuccessStatusCode)
			{
				string responseString = await response.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<ResponseData<List<Stream>>>(responseString);
			}
			else
			{
				return new ResponseData<List<Stream>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<Stream>>> GetStreams(IDictionary<string, string> postParas)
		{
			FormUrlEncodedContent content = new FormUrlEncodedContent(postParas);

			HttpResponseMessage response = await ProxerClient.Client.PostAsync(UrlCollection.AnimeStreams, content);

			if (response.IsSuccessStatusCode)
			{
				string responseString = await response.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<ResponseData<List<Stream>>>(responseString);
			}
			else
			{
				return new ResponseData<List<Stream>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetIncrementCount(IDictionary<string, string> postParas)
		{
			FormUrlEncodedContent content = new FormUrlEncodedContent(postParas);

			HttpResponseMessage response = await ProxerClient.Client.PostAsync(UrlCollection.AnimeIncrementCount, content);

			if (response.IsSuccessStatusCode)
			{
				string responseString = await response.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<ResponseData>(responseString);
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}

		#endregion Public Methods
	}
}