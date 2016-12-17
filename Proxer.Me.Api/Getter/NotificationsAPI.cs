using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Notification;

namespace Proxer.Me.Api.Getter
{
	public class NotificationsAPI
	{
		public static async Task<ResponseData<int[]>> GetCount()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.NotificationsCount, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var count = JsonConvert.DeserializeObject<ResponseData<int[]>>(responseString);
				return count;
			}
			else
			{
				return new ResponseData<int[]>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<News>>> GetNews(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.NotificationsNews, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var news = JsonConvert.DeserializeObject<ResponseData<List<News>>>(responseString);
				return news;
			}
			else
			{
				return new ResponseData<List<News>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> SetDelete(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.NotificationsDelete, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var delete = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return delete;
			}
			else
			{
				return new ResponseData() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}