using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.UWP.Core
{
	public class StreamProvider
	{
		public static string[] Supported { get; }

		static StreamProvider()
		{
			Instance = new StreamProvider();
			Supported = new string[]
			{
				"mp4upload",
				"proxer.me"
			};
		}

		public static StreamProvider Instance { get; }

		public async Task<string> GetMP4UploadVideoSourceAsync(WebView webview, int providerCount)
		{
			string videoUrl = await webview.InvokeScriptAsync("eval", new string[]
				{
					"jwplayer.call().config.file"
				});
			if (string.IsNullOrWhiteSpace(videoUrl))
			{
				return "about:blank";
			}
			return videoUrl;
		}

		public async Task<string> GetProxerMeVideoSourceAsync(WebView webview, int providerCount)
		{
			string videoUrl = await webview.InvokeScriptAsync("eval", new string[]
				{
					"jwplayer.call().getConfig().file"
				});
			if (string.IsNullOrWhiteSpace(videoUrl))
			{
				return "about:blank";
			}
			return videoUrl;
		}
	}
}