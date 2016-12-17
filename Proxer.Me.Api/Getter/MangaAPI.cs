using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Manga;

namespace Proxer.Me.Api.Getter
{
	public class MangaAPI
	{
		public static async Task<ResponseData<Chapter>> GetChapter(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MangaChapter, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var chapter = JsonConvert.DeserializeObject<ResponseData<Chapter>>(responseString);
				return chapter;
			}
			else
			{
				return new ResponseData<Chapter>() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}