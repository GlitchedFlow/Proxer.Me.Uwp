using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;

namespace Proxer.Me.Records
{
	public class EntryContentRecord
	{
		public int Number { get; }

		public int EID { get; }

		public bool IsWatched { get; }

		public List<EntryContentLanguage> Languages { get; } = new List<EntryContentLanguage>();

		public EntryContentRecord(int Number, int EID, bool IsWatched, IEnumerable<EntryContentLanguage> Languages)
		{
			this.Number = Number;
			this.EID = EID;
			this.IsWatched = IsWatched;
			this.Languages.AddRange(Languages);
		}
	}

	public class EntryContentLanguage
	{
		private string _title;
		public string Title
		{
			get
			{
				if (_title == null)
				{
					if (IsAnime)
					{
						return Name + " Episode " + Number;
					}
					else
					{
						return Name + " Chapter " + Number;
					}
				}
				else
				{
					return _title;
				}
			}
		}

		public bool IsAnime { get; }

		public string Name { get; }

		public int Number { get; }

		public string Language { get; }

		public List<string> Hosters { get; } = new List<string>();

		public List<string> HosterImages { get; } = new List<string>();

		public EntryContentLanguage(string title, bool isAnime, string name, int number, string language, IEnumerable<string> hosters, IEnumerable<string> hosterImages)
		{
			_title = title;
			IsAnime = isAnime;
			Name = name;
			Number = number;
			Language = language;
			if (hosters != null)
			{
				foreach (var hoster in hosters)
				{
					Hosters.Add(hoster);
				}
			}
			if (hosterImages != null)
			{
				foreach (var image in hosterImages)
				{
					HosterImages.Add("https://proxer.me/images/hoster/" + image);
				}
			}
			else
			{
				HosterImages.Add("https://proxer.me/images/misc/manga.png");
			}
		}

		public EntryContentLanguage(bool isAnime, string name, int number)
		{
			IsAnime = isAnime;
			Name = name;
			Number = number;
		}
	}


}
