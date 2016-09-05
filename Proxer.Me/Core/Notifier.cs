using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.Core
{
	public class Notifier : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged([CallerMemberName] string Property = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
		}
	}
}
