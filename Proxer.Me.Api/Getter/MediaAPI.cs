using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Media;

namespace Proxer.Me.Api.Getter
{
	public static class MediaAPI
	{
		#region Public Methods

		public static async Task<ResponseData<List<HeaderList>>> GetHeaderList()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MediaHeaderList, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var headerList = JsonConvert.DeserializeObject<ResponseData<List<HeaderList>>>(responseString);
				return headerList;
			}
			else
			{
				return new ResponseData<List<HeaderList>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<RandomHeader>> GetRandomHeader(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.MediaRandomHeader, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var randomHeader = JsonConvert.DeserializeObject<ResponseData<RandomHeader>>(responseString);
				return randomHeader;
			}
			else
			{
				return new ResponseData<RandomHeader>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		#endregion Public Methods
	}
}