using System.Collections.Generic;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace Proxer.Me.UWP.Models
{
	public class AnimePlayerModel : ContentModel
	{
		private Dictionary<string, string> streams;

		public Dictionary<string, string> Streams
		{
			get { return streams; }
			set { Set(ref streams, value); }
		}

		public int SelectedIndex
		{
			get { return selectedIndex; }
			set
			{
				selectedIndex = value;
				RaisePropertyChanged(nameof(SelectedIndex));
			}
		}

		public string VideoUrl
		{
			get { return videoUrl; }
			set
			{
				Set(ref videoUrl, value);
				RaisePropertyChanged(nameof(VideoSource));
			}
		}

		public IMediaPlaybackSource VideoSource
		{
			get
			{
				if (string.IsNullOrWhiteSpace(VideoUrl))
				{
					return null;
				}
				return MediaSource.CreateFromUri(new System.Uri(VideoUrl));
			}
		}

		public bool IsExternal
		{
			get { return isExternal; }
			set { Set(ref isExternal, value); }
		}

		private string videoUrl;

		private int selectedIndex;

		private bool isExternal;
	}
}