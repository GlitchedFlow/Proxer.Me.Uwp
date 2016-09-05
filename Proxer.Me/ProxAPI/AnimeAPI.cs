using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxData.Anime;
using Proxer.Me.ProxData.Media;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxAPI
{
	public class AnimeAPI
	{
		private const string StreamsURL = "https://proxer.me/api/v1/anime/streams";

		private const string ProxerStreamsURL = "https://proxer.me/api/v1/anime/proxerstreams";

		private const string IncrementCountURL = "https://proxer.me/api/v1/anime/incrementcount";

		public static async Task<Streams> GetStreams(int id, int episode, AnimeLanguage language)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", id.ToString() },
					{ "episode", episode.ToString() },
					{ "language", language.ToString().ToLower() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(StreamsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var streams = JsonConvert.DeserializeObject<Streams>(responseString);
				return streams;
			}
			else
			{
				return new Streams() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Streams> GetProxerStreams(int id, int episode, AnimeLanguage language)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", id.ToString() },
					{ "episode", episode.ToString() },
					{ "language", language.ToString().ToLower() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(ProxerStreamsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var streams = JsonConvert.DeserializeObject<Streams>(responseString);
				return streams;
			}
			else
			{
				return new Streams() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<IncrementCount> SetIncrementCount(int id)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", id.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(IncrementCountURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var count = JsonConvert.DeserializeObject<IncrementCount>(responseString);
				return count;
			}
			else
			{
				return new IncrementCount() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}
