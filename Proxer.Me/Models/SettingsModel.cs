using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxSupport;

namespace Proxer.Me.Models
{
	public class SettingsModel : Model
	{
		private ObservableCollection<HomePage> homePages = new ObservableCollection<HomePage>();

		public ObservableCollection<HomePage> HomePages
		{
			get { return homePages; }
		}

		public ObservableCollection<ListStyle> ListStyles
		{
			get { return _listStyles; }
		}

		public ObservableCollection<ListSort> ListSorts
		{
			get { return _listSorts; }
		}

		public ObservableCollection<RatingStyle> RatingStyles
		{
			get { return _ratingStyles; }
		}

		public ObservableCollection<Style> Styles
		{
			get { return _styles; }
		}

		private ObservableCollection<ListStyle> _listStyles = new ObservableCollection<ListStyle>();

		private ObservableCollection<ListSort> _listSorts = new ObservableCollection<ListSort>();

		private ObservableCollection<RatingStyle> _ratingStyles = new ObservableCollection<RatingStyle>();

		private ObservableCollection<Style> _styles = new ObservableCollection<Style>();

		public SettingsModel()
		{
			foreach (var item in Enum.GetNames(typeof(HomePage)))
			{
				HomePages.Add((HomePage)Enum.Parse(typeof(HomePage), item));
			}
			foreach (var item in Enum.GetNames(typeof(ListStyle)))
			{
				ListStyles.Add((ListStyle)Enum.Parse(typeof(ListStyle), item));
			}
			foreach (var item in Enum.GetNames(typeof(ListSort)))
			{
				ListSorts.Add((ListSort)Enum.Parse(typeof(ListSort), item));
			}
			foreach (var item in Enum.GetNames(typeof(RatingStyle)))
			{
				RatingStyles.Add((RatingStyle)Enum.Parse(typeof(RatingStyle), item));
			}
			foreach (var item in Enum.GetNames(typeof(Style)))
			{
				Styles.Add((Style)Enum.Parse(typeof(Style), item));
			}
		}

	}
}
