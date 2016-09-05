using System.Collections.ObjectModel;
using Proxer.Me.Records;

namespace Proxer.Me.Models
{
	public class EntryModel : Model
	{
		private int _currentCommentPage;
		private int _currentEpisodePage;
		private EntryRecord _data = new EntryRecord();

		private int _entryID;
		private bool _loadedComments;

		private bool _loadedEpisodes;

		private bool _loadedGroups;
		private bool _loadedNames;

		private bool _loadedPublishers;
		private bool _loadedRelations;

		private bool _loadedSeasons;
		private bool _loadedTags;
		private bool _loadedUpdates;

		private int _selectedContent = 0;

		private int _selectedInfo = 0;

		private ObservableCollection<EntryContentPageRecord> _pages = new ObservableCollection<EntryContentPageRecord>();
		private ObservableCollection<EntryLanguageRecord> _languages = new ObservableCollection<EntryLanguageRecord>();
		private ObservableCollection<EntryContentRecord> _content = new ObservableCollection<EntryContentRecord>();
		private ObservableCollection<EntryCommentRecord> _comments = new ObservableCollection<EntryCommentRecord>();
		private ObservableCollection<RelationRecord> _relations = new ObservableCollection<RelationRecord>();

		private EntryContentPageRecord _selectedContentPage;

		public int CurrentCommentPage
		{
			get { return _currentCommentPage; }
			set
			{
				if (_currentCommentPage != value)
				{
					_currentCommentPage = value;
					NotifyPropertyChanged();
				}
			}
		}

		public int CurrentEpisodePage
		{
			get { return _currentEpisodePage; }
			set
			{
				if (_currentEpisodePage != value)
				{
					_currentEpisodePage = value;
					NotifyPropertyChanged();
				}
			}
		}

		public EntryRecord Data
		{
			get { return _data; }
			set
			{
				_data = value;
				NotifyPropertyChanged();
			}
		}

		public int EntryID
		{
			get { return _entryID; }
			set
			{
				if (_entryID != value)
				{
					_entryID = value;
					NotifyPropertyChanged();
					CurrentEpisodePage = 0;
					CurrentCommentPage = 0;
					LoadedComments = false;
					LoadedEpisodes = false;
					LoadedGroups = false;
					LoadedNames = false;
					LoadedPublishers = false;
					LoadedRelations = false;
					LoadedSeasons = false;
					LoadedTags = false;
					LoadedUpdates = false;
					LoadedDetails = false;
				}
			}
		}
		public bool LoadedComments
		{
			get { return _loadedComments; }
			set
			{
				_loadedComments = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedEpisodes
		{
			get { return _loadedEpisodes; }
			set
			{
				_loadedEpisodes = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedGroups
		{
			get { return _loadedGroups; }
			set
			{
				_loadedGroups = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedNames
		{
			get { return _loadedNames; }
			set
			{
				_loadedNames = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedPublishers
		{
			get { return _loadedPublishers; }
			set
			{
				_loadedPublishers = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedRelations
		{
			get { return _loadedRelations; }
			set
			{
				_loadedRelations = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedSeasons
		{
			get { return _loadedSeasons; }
			set
			{
				_loadedSeasons = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedTags
		{
			get { return _loadedTags; }
			set
			{
				_loadedTags = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedUpdates
		{
			get { return _loadedUpdates; }
			set
			{
				_loadedUpdates = value;
				NotifyPropertyChanged();
			}
		}

		public int SelectedContent
		{
			get { return _selectedContent; }
			set
			{
				if (_selectedContent != value)
				{
					_selectedContent = value;
					NotifyPropertyChanged();
				}
			}
		}
		public int SelectedInfo
		{
			get { return _selectedInfo; }
			set
			{
				_selectedInfo = value;
				NotifyPropertyChanged();
			}
		}

		public bool LoadedDetails
		{
			get { return _loadedDetails; }
			set
			{
				_loadedDetails = value;
				NotifyPropertyChanged();
			}
		}

		public ObservableCollection<EntryContentPageRecord> Pages
		{
			get { return _pages; }
		}

		public EntryContentPageRecord SelectedContentPage
		{
			get { return _selectedContentPage; }
			set
			{
				_selectedContentPage = value;
				NotifyPropertyChanged();
				if (SelectedContentPage == null)
				{
					CurrentEpisodePage = 0;
				}
				else
				{
					CurrentEpisodePage = SelectedContentPage.Page;
				}
			}
		}

		public ObservableCollection<EntryLanguageRecord> Languages
		{
			get { return _languages; }
		}

		public ObservableCollection<EntryContentRecord> Content
		{
			get { return _content; }
		}

		public ObservableCollection<EntryCommentRecord> Comments
		{
			get { return _comments; }
		}

		private bool _loadedDetails;

		public bool HasCommentNextPage { get; set; }

		public ObservableCollection<RelationRecord> Relations
		{
			get { return _relations; }
		}
	}
}