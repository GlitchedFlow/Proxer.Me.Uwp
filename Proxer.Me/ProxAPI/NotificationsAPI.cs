using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxData.Notification;

namespace Proxer.Me.ProxAPI
{
	public class NotificationsAPI
	{
		private const string CountURL = "https://proxer.me/api/v1/notifications/count";

		private const string NewsURL = "https://proxer.me/api/v1/notifications/news";

		private const string DeleteURL = "https://proxer.me/api/v1/notifications/delete";

		public static async Task<Count> GetCount()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(CountURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var count = JsonConvert.DeserializeObject<Count>(responseString);
				return count;
			}
			else
			{
				return new Count() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<News> GetNews(int page = 0, int limit = 15)
		{
			var values = new Dictionary<string, string>
			{
				{ "p", page.ToString() },
				{ "limit", limit.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(NewsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var news = JsonConvert.DeserializeObject<News>(responseString);
				return news;
			}
			else
			{
				return new News() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Delete> SetDelete(int nid = 0)
		{
			var values = new Dictionary<string, string>
			{
				{ "nid", nid.ToString() }				
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(DeleteURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var delete = JsonConvert.DeserializeObject<Delete>(responseString);
				return delete;
			}
			else
			{
				return new Delete() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}
