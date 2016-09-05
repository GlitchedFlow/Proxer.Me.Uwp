using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxData.List.Data;
using Proxer.Me.Records;

namespace Proxer.Me.Models
{
	public class AnimeOverviewModel : Model
	{
		private ObservableCollection<EntryListRecord> _data = new ObservableCollection<EntryListRecord>();

		public ObservableCollection<EntryListRecord> Data
		{
			get { return _data; }
			set
			{
				_data = value;
				NotifyPropertyChanged();
			}
		}

		public int SelectedType
		{
			get { return _selectedType; }
			set
			{
				_selectedType = value;
				NotifyPropertyChanged();
			}
		}

		public int SelectedSort
		{
			get
			{
				return _selectedSort;
			}

			set
			{
				_selectedSort = value;
				NotifyPropertyChanged();
			}
		}

		public bool IsListSelected
		{
			get
			{
				return Convert.ToBoolean(SelectedOutput);
			}
		}

		public int SelectedOutput
		{
			get { return _selectedOutput; }
			set
			{
				_selectedOutput = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(nameof(IsListSelected));
			}
		}

		public int SelectedLetter
		{
			get { return _selectedLetter; }
			set
			{
				_selectedLetter = value;
				NotifyPropertyChanged();
			}
		}

		public int CurrentPage { get; set; } = 0;

		private int _selectedType;

		private int _selectedSort;

		private int _selectedOutput;

		private int _selectedLetter;

		public bool HasNextPage { get; set; }

		public AnimeOverviewModel()
		{
			SelectedOutput = Settings.ListStyle == ProxSupport.ListStyle.List ? 0 : 1;
		}
	}
}