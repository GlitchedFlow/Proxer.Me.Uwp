using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxData.List.Data;

namespace Proxer.Me.Records
{
	public class EntryListRecord
	{
		private EntryListData _data;

		public EntryListRecord(EntryListData Data)
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

		public string Genre
		{
			get
			{
				return Data.Genre;
			}
		}

		public string Rating
		{
			get
			{
				if (Data.RateCount == 0)
				{
					return "";
				}
				return ((double)Data.RateSum / (double)Data.RateCount).ToString("#.##");
			}
		}

		public double RatingValue
		{
			get
			{
				if (Data.RateCount == 0)
				{
					return 100;
				}
				return 100 - ((100 * ((double)Data.RateSum / (double)Data.RateCount)) / 10);
			}
		}

		public double RatingProgressValue
		{
			get
			{
				if (Data.RateCount == 0)
				{
					return 100;
				}
				return 100 - ((100 * ((double)Data.RateSum / (double)Data.RateCount)) / 10);
			}
		}

		public bool IsRated
		{
			get
			{
				if (Data == null)
				{
					return false;
				}
				if (Data.RateCount == 0)
				{
					return false;
				}
				return true;
			}
		}

		public bool IsRecommended
		{
			get
			{
				if (Data == null)
				{
					return false;
				}
				if (Data.RateCount == 0)
				{
					return false;
				}
				return ((double)Data.RateSum / (double)Data.RateCount) >= Settings.Instance.RecommendationValue;
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
						return "ms-appx:///Assets/Proxer/Status/abgebrochen.png";

					case 1:
					case 4:
						return "ms-appx:///Assets/Proxer/Status/abgeschlossen.png";

					case 2:
						return "ms-appx:///Assets/Proxer/Status/airing.png";
				}
				return "";
			}
		}

		public bool IsGermanOnline
		{
			get
			{
				return Data.Language.Contains("ge") | Data.Language.Contains("de");
			}
		}

		public bool IsEnglishOnline
		{
			get
			{
				return Data.Language.Contains("en");
			}
		}

		public EntryListData Data
		{
			get
			{
				return _data;
			}
		}
	}
}