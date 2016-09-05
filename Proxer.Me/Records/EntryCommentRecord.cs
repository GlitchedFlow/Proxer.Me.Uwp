using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.ProxData.Info.Data;

namespace Proxer.Me.Records
{
	public class EntryCommentRecord
	{
		private int rating;
		public string Comment { get; }
		public string Avatar { get; }
		public string Username { get; }
		public string State { get; }

		public int UID { get; }

		public List<int> Rating
		{
			get
			{
				var result = new List<int>();
				int tempRating = rating;
				int index = 0;
				while (tempRating > 1)
				{
					result.Add(1);
					tempRating -= 1;
					index++;
				}
				result.Add(tempRating);
				while (result.Count < 10)
				{
					result.Add(0);
				}
				return result;
			}
		}
		public int Episode { get; }
		public int Positive { get; }
		public int TimeStamp { get; }

		public bool HasDetails { get; }

		public IDictionary<string, List<int>> Details { get; } = new Dictionary<string, List<int>>();

		public EntryCommentRecord(CommentData data, bool IsManga)
		{
			Comment = data.Comment;
			Avatar = string.IsNullOrWhiteSpace(data.Avatar) ? "https://cdn.proxer.me/avatar/tn/nophoto.png" : $"https://cdn.proxer.me/avatar/tn/{data.Avatar}";
			Username = data.Username;
			UID = data.UID;
			switch (data.State)
			{
				case 0:
					State = "Abgeschlossen";
					break;
				case 1:
					State = IsManga ? "Am Lesen (" + data.Episode + ")" : "Am Schauen (" + data.Episode + ")";
					break;
				case 2:
					State = IsManga ? "Wird noch gelesen" : "Wird noch geschaut";
					break;
				case 3:
					State = "Abgebrochen";
					break;
			}
			rating = data.Rating;
			Episode = data.Episode;
			Positive = data.Positive;
			TimeStamp = data.TimeStamp;
			if (data.Data.ToString() != "[]")
			{
				var tempDetails = (Dictionary<string, int>)JsonConvert.DeserializeObject(data.Data.ToString(), typeof(Dictionary<string, int>));
				if (tempDetails != null)
				{
					foreach (var item in tempDetails)
					{
						var rate = new List<int>();
						int tempRating = item.Value;
						int index = 0;
						while (tempRating > 1)
						{
							rate.Add(1);
							tempRating -= 1;
							index++;
						}
						rate.Add(tempRating);
						Details.Add(char.ToUpper(item.Key[0]) + item.Key.Substring(1), rate);
					}
					HasDetails = true;
				}
			}
		}
	}
}
