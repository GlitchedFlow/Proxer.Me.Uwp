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
	public class MediaAPI
	{
		private const string RandomHeaderURL = "https://proxer.me/api/v1/media/randomheader";

		private const string HeaderListURL = "https://proxer.me/api/v1/media/headerlist";

		public static async Task<RandomHeader> GetRandomHeader(ProxStyles style = ProxStyles.Gray)
		{
			var values = new Dictionary<string, string>
				{
					{ "style", style.ToString().ToLower() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(RandomHeaderURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var randomHeader = JsonConvert.DeserializeObject<RandomHeader>(responseString);
				return randomHeader;
			}
			else
			{
				return new RandomHeader() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<HeaderList> GetHeaderList()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(HeaderListURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var headerList = JsonConvert.DeserializeObject<HeaderList>(responseString);
				return headerList;
			}
			else
			{
				return new HeaderList() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}
