namespace Proxer.Me.UWP.Models
{
	public class LoginModel : ProxerModel
	{
		public bool ExecuteAutoLogin
		{
			get { return _executeAutoLogin; }
			set { Set(ref _executeAutoLogin, value); }
		}

		public string JapaneseInfo
		{
			get { return _japaneseInfo; }
			set { Set(ref _japaneseInfo, value); }
		}

		public string Password
		{
			get { return _password; }
			set { Set(ref _password, value); }
		}

		private string _password;

		private bool _executeAutoLogin = false;

		private string _japaneseInfo = "いってらっしゃい";
	}
}