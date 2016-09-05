using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.User.Data;

namespace Proxer.Me.Records
{
	public class ProfileListRecord
	{
		private ListData _data;

		public ProfileListRecord(ListData Data)
		{
			this._data = Data;
		}

		public string Name
		{
			get { return Data.Name; }
		}

		public string Cover
		{
			get
			{
				return $"http://cdn.proxer.me/cover/{Data.ID}.jpg";
			}
		}

		public string Medium
		{
			get
			{
				switch (Data.Medium)
				{
					case ProxSupport.Medium.AnimeSeries:
						return "Animeserie";
					case ProxSupport.Medium.MangaSeries:
						return "Manga";
					case ProxSupport.Medium.HManga:
						return "H-Manga";
					case ProxSupport.Medium.None:
						return "";
					default:
						return Data.Medium.ToString();
				}
			}
		}

		public List<int> Rating
		{
			get
			{
				var result = new List<int>();
				if (Data.Rating == 0)
				{
					return result;
				}
				int rating = Data.Rating;
				int index = 0;
				while (rating > 1)
				{
					result.Add(1);
					rating -= 1;
					index++;
				}
				result.Add(rating);
				while (result.Count < 10)
				{
					result.Add(0);
				}
				return result;
			}
		}

		public int Watched
		{
			get { return Data.Episode; }
		}

		public int Online
		{
			get { return Data.Count; }
		}

		public bool IsRated
		{
			get
			{
				if (Data == null)
				{
					return false;
				}
				if (Data.Rating == 0)
				{
					return false;
				}
				return true;
			}
		}

		public string StateImage
		{
			get
			{
				switch (Data.State)
				{
					case 0:
					case 3:
						return "https://proxer.me/images/status/abgebrochen.png";
					case 1:
					case 4:
						return "https://proxer.me/images/status/abgeschlossen.png";
					case 2:
						return "https://proxer.me/images/status/airing.png";
				}
				return "";
			}
		}

		public ListData Data
		{
			get
			{
				return _data;
			}
		}
	}
}
