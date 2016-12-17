using System;
using Proxer.Me.Support.Api.Data.Info;
using Proxer.Me.Support.Interfaces;

namespace Proxer.Me.UWP.Models
{
	public class ContentModel : PaneModel
	{
		public string Url
		{
			get { return url; }
			set { Set(ref url, value); }
		}

		public Entry Entry
		{
			get { return entry; }
			set
			{
				Set(ref entry, value);
				RaisePropertyChanged(nameof(PageTitle));
			}
		}

		private Entry entry;

		private int number;

		public string PageTitle
		{
			get
			{
				if (Entry != null)
				{
					return Entry.Name;
				}
				return "";
			}
		}

		public string Title
		{
			get { return title; }
			set { Set(ref title, value); }
		}

		private string language;
		private string uploader;

		private string group;

		private DateTime uploadDate;

		public string Language
		{
			get { return language; }
			set { Set(ref language, value); }
		}

		public string Uploader
		{
			get { return uploader; }
			set { Set(ref uploader, value); }
		}

		public string Group
		{
			get { return group; }
			set { Set(ref group, value); }
		}

		public DateTime UploadDate
		{
			get { return uploadDate; }
			set { Set(ref uploadDate, value); }
		}

		public int Number
		{
			get { return number; }
			set { Set(ref number, value); }
		}

		private string title;

		private string contentType;

		public IContentInfo Info { get; set; }

		public bool ShowDate
		{
			get { return showDate; }
			set { Set(ref showDate, value); }
		}

		public string ContentType
		{
			get { return contentType; }
			set { Set(ref contentType, value); }
		}

		public string UploadType
		{
			get { return uploadType; }
			set { Set(ref uploadType, value); }
		}

		public string GroupType
		{
			get { return groupType; }
			set { Set(ref groupType, value); }
		}

		private string uploadType;

		private string groupType;

		private bool showDate;

		private string url;
	}
}