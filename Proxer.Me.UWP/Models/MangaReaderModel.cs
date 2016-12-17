using System.Collections.ObjectModel;

namespace Proxer.Me.UWP.Models
{
	public class MangaReaderModel : ContentModel
	{
		private ObservableCollection<string> images;

		public ObservableCollection<string> Images
		{
			get { return images; }
			set { Set(ref images, value); }
		}
	}
}