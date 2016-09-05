using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.Notification.Data;
using Proxer.Me.Records;

namespace Proxer.Me.Models
{
	public class NewsModel : Model
	{
		public ObservableCollection<NewsRecord> News { get; set; } = new ObservableCollection<NewsRecord>();

		public int CurrentPage { get; set; } = 0;

		public bool HasNextPage { get; set; }
	}
}
