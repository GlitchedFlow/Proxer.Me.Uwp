using System.Net;
using System.Net.Http;

namespace Proxer.Me.Api
{
	public static class ProxerClient
	{
		static ProxerClient()
		{
			Cookies = new CookieContainer();
			Client = new HttpClient(new HttpClientHandler() { CookieContainer = Cookies });
			Client.DefaultRequestHeaders.Add("proxer-api-key", APIKey);
		}

		public static HttpClient Client { get; }

		public static CookieContainer Cookies { get; }

		private const string APIKey = "";
	}
}