using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.Models;
using Proxer.Me.ProxData.Info.Data;

namespace Proxer.Me.Records
{
	public class EntryRecord : Notifier
	{
		private EntryData _details;
		private ObservableCollection<NameRecord> _names = new ObservableCollection<NameRecord>();
		private ObservableCollection<TagRecord> _tags = new ObservableCollection<TagRecord>();
		private ObservableCollection<SeasonData> _seasons = new ObservableCollection<SeasonData>();
		private ObservableCollection<PeopleRecord> _people = new ObservableCollection<PeopleRecord>();
		private ObservableCollection<FSKRecord> _fsk = new ObservableCollection<FSKRecord>();

		public string Cover
		{
			get
			{
				if (Details == null)
				{
					return "";
				}
				return $"https://cdn.proxer.me/cover/{Details.ID}.jpg";
			}
		}

		public EntryData Details
		{
			get { return _details; }
			set
			{
				_details = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(nameof(Cover));
				NotifyPropertyChanged(nameof(IsRated));
				NotifyPropertyChanged(nameof(RatingValue));
				NotifyPropertyChanged(nameof(RatingProgressValue));
				NotifyPropertyChanged(nameof(Rating));
			}
		}

		public List<double> Rating
		{
			get
			{
				var result = new List<double>();
				if (Details == null)
				{
					return result;
				}
				double rating = RatingValue;
				int index = 0;
				while (rating > 1)
				{
					result.Add(1.0);
					rating -= 1;
					index++;
				}
				result.Add(rating);
				return result;
			}
		}

		public double RatingValue
		{
			get
			{
				if (Details == null)
				{
					return 0;
				}
				return Convert.ToDouble(((double)Details.RateSum / (double)Details.RateCount).ToString("#.##"));
			}
		}

		public double RatingProgressValue
		{
			get
			{
				if (Details == null)
				{
					return 100;
				}
				return 100 - ((100 * ((double)Details.RateSum / (double)Details.RateCount)) / 10);
			}
		}

		public bool IsRated
		{
			get
			{
				if (Details == null)
				{
					return false;
				}
				if (Details.RateCount == 0)
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
				if (Details == null)
				{
					return false;
				}
				if (Details.RateCount == 0)
				{
					return false;
				}
				return ((double)Details.RateSum / (double)Details.RateCount) >= Settings.Instance.RecommendationValue;
			}
		}

		public ObservableCollection<NameRecord> Names
		{
			get { return _names; }
		}

		public ObservableCollection<TagRecord> Tags
		{
			get { return _tags; }
		}

		public ObservableCollection<SeasonData> Seasons
		{
			get { return _seasons; }
		}

		public ObservableCollection<PeopleRecord> People
		{
			get { return _people; }
		}

		public ObservableCollection<FSKRecord> Fsk
		{
			get { return _fsk; }
		}
	}
}