using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Proxer.Me.Api.Getter;
using Proxer.Me.Controls.Converters;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Info;
using Proxer.Me.Support.Api.Data.Manga;
using Proxer.Me.Support.Interfaces;
using Proxer.Me.UWP.Models;
using Proxer.Me.UWP.UserControls;
using Proxer.Me.UWP.Wrapper;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class MangaReaderViewModel : PaneViewModel<MangaReaderModel>
	{
		private bool infosLoaded = false;
		private bool failed = false;

		public ICommand NavgationCompleted { get; private set; }

		public DelegateCommand PreviousChapter { get; private set; }

		public DelegateCommand NextChapter { get; private set; }

		public ICommand ShowNotes { get; private set; }

		public ICommand SetReminder { get; private set; }

		public MangaReaderViewModel() : base(new MangaReaderModel())
		{
			Model.Images = new ObservableCollection<string>();
			Model.ContentType = "Kapitel";
			Model.UploadType = "Uploader";
			Model.GroupType = "Scanlator-Gruppe";
			NavgationCompleted = new DelegateCommand<WebView>(ExecuteNavgationCompleted);
			PreviousChapter = new DelegateCommand(ExecutePreviousChapter, CanExecutePreviousChapter);
			NextChapter = new DelegateCommand(ExecuteNextChapter, CanExecuteNextChapter);
			ShowNotes = new DelegateCommand(ExecuteShowNotes, CanExecuteShowNotes);
			SetReminder = new DelegateCommand(ExecuteSetReminder, CanExecuteSetReminder);
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
			await loadChapter(new ContentInfo() { ID = Model.Info.ID, Number = Model.Info.Number + 1, Language = Model.Info.Language }, false);
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
			await loadChapter(new ContentInfo() { ID = Model.Info.ID, Number = Model.Info.Number - 1, Language = Model.Info.Language }, false);
		}

		private async void ExecuteNavgationCompleted(WebView webView)
		{
			if (webView.Source.AbsoluteUri != "about:blank")
			{
				if (!infosLoaded)
				{
					await getChapterDetails(webView);
				}
				else
				{
					await getChapterPages(webView);
				}
			}
		}

		private async Task getChapterDetails(WebView webView)
		{
			string count = await webView.InvokeScriptAsync("eval", new string[]
			{
				"$('.details > tbody > tr > td:nth-child(2)').length.toString()"
			});
			int detailsCount = Convert.ToInt32(count);
			for (int i = 0; i < detailsCount; i++)
			{
				string info = await webView.InvokeScriptAsync("eval", new string[]
				{
					$"$($('.details > tbody > tr > td:nth-child(2)')[{i}]).text()"
				});
				switch (i)
				{
					case 0:
						Model.Title = info;
						break;

					case 2:
						Model.Language = info;
						break;

					case 3:
						Model.Uploader = info;
						break;

					case 4:
						Model.Group = info;
						break;

					case 5:
						Model.UploadDate = DateTime.Parse(info);
						break;

					default:
						break;
				}
			}
			infosLoaded = true;
		}

		private async Task getChapterPages(WebView webView)
		{
			await webView.InvokeScriptAsync("eval", new string[]
			{
				"if (get_cookie('manga_reader') != 'longstrip') { set_cookie('manga_reader','longstrip',cookie_expire);location.href = location.href; }"
			});
			string count = await webView.InvokeScriptAsync("eval", new string[]
			{
				"$(\"img[id^='chapterImage']\").length.toString()"
			});
			int imagesCount = Convert.ToInt32(count);
			for (int i = 0; i < imagesCount; i++)
			{
				await webView.InvokeScriptAsync("eval", new string[]
				{
					$"changePage({i}, false)"
				});
			}
			for (int i = 0; i < imagesCount; i++)
			{
				string url = await webView.InvokeScriptAsync("eval", new string[]
				{
					$"$($(\"img[id^='chapterImage']\")[{i}]).attr('src')"
				});
				Model.Images.Add("https://" + url);
			}
			Busy.SetBusy(false);
		}

		public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
		{
			Model.Images.Clear();
			Model.Entry = null;
			Model.Number = 0;
			Model.Url = null;
			await base.OnNavigatingFromAsync(args);
		}

		public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			IContentInfo wrapper = (IContentInfo)parameter;
			await loadChapter(wrapper, true);
			await base.OnNavigatedToAsync(parameter, mode, state);
		}

		private async Task loadChapter(IContentInfo wrapper, bool init)
		{
			Model.Images.Clear();
			if (wrapper != null)
			{
				Model.Info = wrapper;
				Busy.SetBusy(true, "Kapitel wird geladen...");
				Model.Number = wrapper.Number;
				if (init)
				{
					await getEntry(wrapper.ID);
				}
				PreviousChapter.RaiseCanExecuteChanged();
				NextChapter.RaiseCanExecuteChanged();
				if (Model.ShellModel.UseWebReader)
				{
					infosLoaded = false;
					failed = false;
					await getChapterViaWeb(wrapper);
				}
				else
				{
					await getChapterViaApi(wrapper);
				}
			}
		}

		private async Task getChapterViaApi(IContentInfo wrapper)
		{
			Dictionary<string, string> postParas = new Dictionary<string, string>();
			postParas.Add("id", wrapper.ID.ToString());
			postParas.Add("episode", wrapper.Number.ToString());
			postParas.Add("language", wrapper.Language);
			ResponseData<Chapter> response = await MangaAPI.GetChapter(postParas);
			if (response.Error)
			{
				HandleException(response);
			}
			else
			{
				Model.Title = response.Data.Title;
				Model.Language = (string)new LanguageToStringConverter().Convert(wrapper.Language, null, null, null);
				Model.Uploader = response.Data.Username;
				Model.Group = response.Data.TName == null ? "siehe Kapitelcredits" : response.Data.TName;
				System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
				dtDateTime = dtDateTime.AddSeconds(System.Convert.ToDouble(response.Data.TimeStamp)).ToLocalTime();
				Model.UploadDate = dtDateTime;
				for (int i = 0; i < response.Data.Pages.Count; i++)
				{
					Model.Images.Add($"https://manga{response.Data.Server}.proxer.me/f/{wrapper.ID}/{response.Data.CID}/{response.Data.Pages[i][0]}");
				}
				Busy.SetBusy(false);
			}
		}

		private async Task getChapterViaWeb(IContentInfo wrapper)
		{
			string chapterURL = $"https://proxer.me/chapter/{wrapper.ID}/{wrapper.Number}/{wrapper.Language}";
			Model.Url = chapterURL;
			int tryCount = 0;
			while (!infosLoaded)
			{
				tryCount++;
				if (tryCount == 100)
				{
					infosLoaded = true;
					failed = true;
				}
				else
					await Task.Delay(250);
			}
			if (failed)
			{
				Busy.SetBusy(false);
				Info.SetInfo(true, "Da hat etwas nicht funktioniert. Bitte versuch es später erneut.");
			}
			else
			{
				string url = $"https://proxer.me/read/{wrapper.ID}/{wrapper.Number}/{wrapper.Language}/1";
				Model.Url = url;
			}
		}

		private async Task getEntry(int iD)
		{
			ResponseData<Entry> response = await InfoAPI.GetEntry(new Dictionary<string, string>() { { "id", iD.ToString() } });
			if (!response.Error)
			{
				Model.Entry = response.Data;
			}
		}
	}
}