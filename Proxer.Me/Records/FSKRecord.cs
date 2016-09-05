using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;

namespace Proxer.Me.Records
{
	public class FSKRecord : Notifier
	{
		private string _data;

		public string Data
		{
			get { return _data; }
			set
			{
				_data = value;
				NotifyPropertyChanged();
			}
		}

		public FSKRecord(string data)
		{
			Data = data;
		}

		public string Cover
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Data))
				{
					return "";
				}
				return $"ms-appx:///Assets/Proxer/PSK/{Data}.png";
			}
		}
	}
}