using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Core;
using Proxer.Me.ProxData.Info.Data;

namespace Proxer.Me.Records
{
	public class TagRecord : Notifier
	{
		private TagsData _data;
		private string _genre;
		private bool _isGenre;
		private bool _showSpoiler;
		public TagRecord(TagsData data)
		{
			Data = data;
			_isGenre = false;
		}

		public TagRecord(string data)
		{
			Genre = data;
			_isGenre = true;
		}

		public TagsData Data
		{
			get { return _data; }
			set
			{
				_data = value;
				NotifyPropertyChanged();
			}
		}

		public string Content
		{
			get
			{
				if (IsGenre)
				{
					return Genre + " (Genre)";
				}
				else
				{
					if (IsSpoiler & !ShowSpoiler)
					{
						return "(Spoiler)";
					}
					else
					{
						return Data.Tag;
					}
				}
			}
		}

		public string Genre
		{
			get { return _genre; }
			set
			{
				_genre = value;
				NotifyPropertyChanged();
			}
		}

		public bool IsGenre
		{
			get { return _isGenre; }
		}

		public bool ShowSpoiler
		{
			get
			{
				if (IsGenre || !IsSpoiler)
					return true;
				return _showSpoiler;
			}
			set
			{
				_showSpoiler = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(nameof(Content));
			}
		}

		public bool IsSpoiler
		{
			get
			{
				return Convert.ToBoolean(Data.SpoilerFlag);
			}
		}
	}
}
