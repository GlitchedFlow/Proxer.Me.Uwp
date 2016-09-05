using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Models;

namespace Proxer.Me.Core
{
	public class ProxerClient
	{
		static ProxerClient()
		{
			Instance = new ProxerClient();
		}

		ProxerClient()
		{
			Cookies = new CookieContainer();
			Client = new HttpClient(new HttpClientHandler() { CookieContainer = Cookies });
			Client.DefaultRequestHeaders.Add("proxer-api-key", APIKey);
			if (Settings.Instance.UserToken != null)
				Client.DefaultRequestHeaders.Add("proxer-api-token", Settings.Instance.UserToken);
		}

		public static ProxerClient Instance { get; private set; }

		public HttpClient Client { get; private set; }

		public CookieContainer Cookies { get; private set; }

		private const string APIKey = "5EDh2NzHICQ1Rvo2630WRdH5XkiGVLiY";
	}
}
