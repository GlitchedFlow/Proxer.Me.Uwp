using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class CommentRatingDetailsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();
			if (value.ToString() != "[]")
			{
				var tempDetails = (Dictionary<string, int>)JsonConvert.DeserializeObject(value.ToString(), typeof(Dictionary<string, int>));
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
						result.Add(char.ToUpper(item.Key[0]) + item.Key.Substring(1), rate);
					}
				}
			}
			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}
