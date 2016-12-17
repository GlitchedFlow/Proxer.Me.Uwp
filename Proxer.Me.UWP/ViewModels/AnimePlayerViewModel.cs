using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Info;
using Proxer.Me.Support.Interfaces;
using Proxer.Me.UWP.Core;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Wrapper;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class AnimePlayerViewModel : PaneViewModel<AnimePlayerModel>
	{
		private bool streamsLoaded = false;
		private WebView webView;
		private int proxerProviderCount;

		public ICommand NavgationCompleted { get; private set; }

		public ICommand OpenInBrowser { get; private set; }

		public DelegateCommand PreviousChapter { get; private set; }

		public DelegateCommand NextChapter { get; private set; }

		public ICommand ShowNotes { get; private set; }

		public ICommand SetReminder { get; private set; }

		public AnimePlayerViewModel() : base(new AnimePlayerModel())
		{
			Model.Streams = new Dictionary<string, string>();
			NavgationCompleted = new DelegateCommand<WebView>(ExecuteNavgationCompleted);
			NavgationCompleted = new DelegateCommand<WebView>(ExecuteNavgationCompleted);
			PreviousChapter = new DelegateCommand(ExecutePreviousChapter, CanExecutePreviousChapter);
			NextChapter = new DelegateCommand(ExecuteNextChapter, CanExecuteNextChapter);
			ShowNotes = new DelegateCommand(ExecuteShowNotes, CanExecuteShowNotes);
			SetReminder = new DelegateCommand(ExecuteSetReminder, CanExecuteSetReminder);
			OpenInBrowser = new DelegateCommand(ExecuteOpenInBrowser);
			Model.ContentType = "Folge";
			Model.Uploader = "-";
			Model.UploadType = "Verlinker";
			Model.GroupType = "Subgruppe";
			Model.ShowDate = false;
			Model.PropertyChanged += Model_PropertyChanged;
		}

		private async void ExecuteOpenInBrowser()
		{
			string url = Model.Streams.ToList()[Model.SelectedIndex].Value;
			if (url.StartsWith("//"))
			{
				url = url.Insert(0, "http:");
			}
			await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
		}

		private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Model.SelectedIndex))
			{
				if (Model.Streams.Count > 0 && Model.SelectedIndex >= 0)
				{
					Model.Url = Model.Streams.ToList()[Model.SelectedIndex].Value;
				}
			}
		}

		private async Task getVideoUrl()
		{
			if (Model.Streams.Count > Model.SelectedIndex)
			{
				if (Model.Streams.ToList()[Model.SelectedIndex].Value.ToLower().Contains("mp4upload"))
				{
					Model.IsExternal = false;
					Model.VideoUrl = await StreamProvider.Instance.GetMP4UploadVideoSourceAsync(webView, proxerProviderCount);
				}
				else if (Model.Streams.ToList()[Model.SelectedIndex].Value.ToLower().Contains("proxer"))
				{
					Model.IsExternal = false;
					Model.VideoUrl = await StreamProvider.Instance.GetProxerMeVideoSourceAsync(webView, proxerProviderCount);
				}
				else
				{
					Model.IsExternal = true;
				}
			}
		}

		private bool CanExecuteSetReminder()
		{
			return Model.ShellModel.IsUserLoggedIn;
		}

		private async void ExecuteSetReminder()
		{
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", Model.Info.ID.ToString());
			postParas.Add("episode", Model.Info.Number.ToString());
			postParas.Add("language", Model.Info.Language);
			postParas.Add("kat", Model.Entry.Category);
			ResponseData response = await UCPAPI.SetReminder(postParas);
			if (response.Error)
				HandleException(response);
			else
				Info.SetInfo(true, "Lesezeichen gesetzt.");
		}

		private bool CanExecuteShowNotes()
		{
			return false;
		}

		private void ExecuteShowNotes()
		{
			throw new NotImplementedException();
		}

		private bool CanExecuteNextChapter()
		{
			if (Model.Entry == null)
			{
				return false;
			}
			if (Model.Number + 1 > Model.Entry.Count)
			{
				return false;
			}
			return true;
		}

		private async void ExecuteNextChapter()
		{
			await loadStreams(new ContentInfo() { ID = Model.Info.ID, Number = Model.Info.Number + 1, Language = Model.Info.Language }, false);
		}

		private bool CanExecutePreviousChapter()
		{
			if (Model.Number <= 1)
			{
				return false;
			}
			return true;
		}

		private async void ExecutePreviousChapter()
		{
			await loadStreams(new ContentInfo() { ID = Model.Info.ID, Number = Model.Info.Number - 1, Language = Model.Info.Language }, false);
		}

		public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
		{
			Model.Streams.Clear();
			await base.OnNavigatingFromAsync(args);
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			IContentInfo wrapper = (IContentInfo)parameter;
			await loadStreams(wrapper, true);
			await base.OnNavigatedToAsync(parameter, mode, state);
		}

		private async void ExecuteNavgationCompleted(WebView webView)
		{
			if (this.webView == null)
				this.webView = webView;
			if (streamsLoaded)
			{
				await getVideoUrl();
				return;
			}
			if (webView.Source.AbsoluteUri != "about:blank")
			{
				await getStreams(webView);
			}
		}

		private async Task getStreams(WebView webView)
		{
			Model.Language = await webView.InvokeScriptAsync("eval", new string[]
			{
				"$('.wLanguage').text()"
			});
			Model.Group = await webView.InvokeScriptAsync("eval", new string[]
			{
				"$('.wGroup > a').text()"
			});
			if (string.IsNullOrWhiteSpace(Model.Group))
			{
				Model.Group = "-";
			}
			string count = await webView.InvokeScriptAsync("eval", new string[]
			{
				"$('.wMirror > a').length.toString()"
			});
			int providerCount = Convert.ToInt32(count);
			proxerProviderCount = providerCount;
			Dictionary<string, string> newStreams = new Dictionary<string, string>();
			for (int i = 0; i < providerCount; i++)
			{
				string imgLink = await webView.InvokeScriptAsync("eval", new string[]
				{
					$"$($('.wMirror > a > img')[{i}]).attr('src')"
				});
				string streamLink = await webView.InvokeScriptAsync("eval", new string[]
				{
					$"getStreamAjax({i}); $('.wStream > iframe').attr('src')"
				});
				if (!string.IsNullOrWhiteSpace(imgLink) && !string.IsNullOrWhiteSpace(streamLink))
					newStreams.Add("https://proxer.me" + imgLink, streamLink);
			}
			Model.Streams = newStreams;
			Model.SelectedIndex = 0;
			streamsLoaded = true;
			Busy.SetBusy(false);
		}

		private Task getStreamsViaApi(IContentInfo wrapper)
		{
			Busy.SetBusy(false);
			return Task.CompletedTask;
			//Dictionary<string, string> postParas = new Dictionary<string, string>();
			//postParas.Add("id", wrapper.ID.ToString());
			//postParas.Add("episode", wrapper.Number.ToString());
			//postParas.Add("language", wrapper.Language);
			//ResponseData<Chapter> response = await MangaAPI.GetChapter(postParas);
			//if (response.Error)
			//{
			//	HandleException(response);
			//}
			//else
			//{
			//	Model.Title = response.Data.Title;
			//	Model.Language = (string)new LanguageToStringConverter().Convert(wrapper.Language, null, null, null);
			//	Model.Uploader = response.Data.Username;
			//	Model.Group = response.Data.TName == null ? "siehe Kapitelcredits" : response.Data.TName;
			//	System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			//	dtDateTime = dtDateTime.AddSeconds(System.Convert.ToDouble(response.Data.TimeStamp)).ToLocalTime();
			//	Model.UploadDate = dtDateTime;
			//	for (int i = 0; i < response.Data.Pages.Count; i++)
			//	{
			//		Model.Images.Add($"https://manga{response.Data.Server}.proxer.me/f/{wrapper.ID}/{response.Data.CID}/{response.Data.Pages[i][0]}");
			//	}
			//	Busy.SetBusy(false);
			//}
		}

		private Task getStreamsViaWeb(IContentInfo wrapper)
		{
			string watchUrl = $"http://proxer.me/watch/{wrapper.ID}/{wrapper.Number}/{wrapper.Language}";
			Model.Url = watchUrl;
			return Task.CompletedTask;
		}

		private async Task loadStreams(IContentInfo wrapper, bool init)
		{
			Model.Streams.Clear();
			streamsLoaded = false;
			if (wrapper != null)
			{
				Model.Info = wrapper;
				Busy.SetBusy(true, "Folge wird geladen...");
				Model.Number = wrapper.Number;
				if (init)
				{
					await getEntry(wrapper.ID);
				}
				PreviousChapter.RaiseCanExecuteChanged();
				NextChapter.RaiseCanExecuteChanged();
				if (Model.ShellModel.UseWebPlayer)
				{
					await getStreamsViaWeb(wrapper);
				}
				else
				{
					await getStreamsViaApi(wrapper);
				}
			}
		}

		private async Task getEntry(int iD)
		{
			ResponseData<Entry> response = await InfoAPI.GetEntry(new Dictionary<string, string>() { { "id", iD.ToString() } });
			if (!response.Error)
			{
				Model.Entry = response.Data;
				Model.Title = Model.PageTitle;
			}
		}
	}
}