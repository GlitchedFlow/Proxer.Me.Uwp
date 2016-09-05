using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxData.Notification.Data;

namespace Proxer.Me.Records
{
	public class NewsRecord : Notifier
	{
		private NewsData _data;

		public NewsRecord(NewsData Data)
		{
			_data = Data;
		}

		public string Thumbnail
		{
			get
			{
				if (Settings.Instance.ShowNewsImages)
					return "http://cdn.proxer.me/news/th/" + _data.NID + "_" + _data.ImageID + ".png";
				return "";
			}
		}

		public string Title
		{
			get
			{
				return _data.Subject;
			}
		}

		public string Introduction
		{
			get
			{
				return _data.Description;
			}
		}

		public string Author
		{
			get
			{
				return _data.Username;
			}
		}

		public string Date
		{
			get
			{
				System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
				dtDateTime = dtDateTime.AddSeconds(_data.Time).ToLocalTime();
				return (dtDateTime.Day < 10 ? "0" : "") + dtDateTime.Day  + "." + (dtDateTime.Month < 10 ? "0" : "") +  dtDateTime.Month + "." + dtDateTime.Year;
			}
		}

		public int CategoryID
		{
			get
			{
				return _data.CatID;
			}
		}

		public int ThreadID
		{
			get
			{
				return _data.MID;
			}
		}
	}
}
