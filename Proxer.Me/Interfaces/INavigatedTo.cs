using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.Interfaces
{
	public interface INavigatedTo
	{
		void RefreshPageContent();

		void NotifyPropertyChanged(string Property);

		void ModelNotifyPropertyChanged(string Property);
	}
}
