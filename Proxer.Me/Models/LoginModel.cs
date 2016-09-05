using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.Models
{
	public class LoginModel : Model
	{
		private bool _userLoggedIn;

		public bool UserLoggedIn
		{
			get { return _userLoggedIn; }
			set
			{
				_userLoggedIn = value;
				NotifyPropertyChanged();
			}
		}

		public bool ExecuteAutoLogin
		{
			get { return _executeAutoLogin; }
			set
			{
				_executeAutoLogin = value;
				NotifyPropertyChanged();
			}
		}

		public string JapaneseInfo
		{
			get { return _japaneseInfo; }
			set
			{
				_japaneseInfo = value;
				NotifyPropertyChanged();
			}
		}

		private bool _executeAutoLogin = true;

		private string _japaneseInfo = "いってらっしゃい";
	}
}