using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxData.Media;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.ProxAPI
{
	public class MangaAPI
	{
		private const string ChapterURL = "https://proxer.me/api/v1/manga/chapter";

		public static async Task<Chapter> GetChapter(int id, int episode, Language language)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", id.ToString() },
					{ "episode", episode.ToString() },
				};
			if (language == Language.Both)
				values.Add("language", "en");
			else
				values.Add("language", language.ToString().ToLower());

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(ChapterURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var chapter = JsonConvert.DeserializeObject<Chapter>(responseString);
				return chapter;
			}
			else
			{
				return new Chapter() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}
