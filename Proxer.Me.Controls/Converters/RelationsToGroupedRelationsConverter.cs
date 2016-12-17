using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Support.Api.Data.Info;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Converters
{
	public class RelationsToGroupedRelationsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			IEnumerable<Relation> relations = (IEnumerable<Relation>)value;
			if (relations != null)
				return relations.GroupBy(x => x.Year);
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
