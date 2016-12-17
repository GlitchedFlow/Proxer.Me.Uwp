namespace Proxer.Me.UWP.Models
{
	public class WebModel : ProxerModel
	{
		private string source;

		public string Source
		{
			get { return source; }
			set { Set(ref source, value); }
		}

		public string Title
		{
			get { return title; }
			set { Set(ref title, value); }
		}

		private string title = "Web";
	}
}