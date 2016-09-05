using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Models;
using Proxer.Me.ProxData.Info.Data;

namespace Proxer.Me.Records
{
	public class RelationRecord
	{
		private RelationData _data;

		public RelationRecord(RelationData Data)
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
					return "Not Rated";
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
				if (Data.Language != null)
				{
					return Data.Language.Contains("ge") | Data.Language.Contains("de");
				}
				return false;
			}
		}

		public bool IsEnglishOnline
		{
			get
			{
				if (Data.Language != null)
				{
					return Data.Language.Contains("en");
				}
				return false;
			}
		}

		public string Season
		{
			get
			{
				if (Data.Season == null)
				{
					return "-";
				}
				switch (Data.Season)
				{
					case 1:
						return "Winter " + Data.Year;

					case 2:
						return "Frühling " + Data.Year;

					case 3:
						return "Sommer " + Data.Year;

					case 4:
						return "Herbst " + Data.Year;
				}
				return "-";
			}
		}

		public RelationData Data
		{
			get
			{
				return _data;
			}
		}
	}
}