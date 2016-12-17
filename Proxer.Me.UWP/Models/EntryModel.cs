using System.Collections.ObjectModel;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.Info;
using Proxer.Me.Support.Records;

namespace Proxer.Me.UWP.Models
{
	public class EntryModel : PaneModel
	{
		private FullEntry fullEntry;

		public FullEntry FullEntry
		{
			get { return fullEntry; }
			set
			{
				Set(ref fullEntry, value);
				RaisePropertyChanged(nameof(ContentTab));
			}
		}

		public string ContentTab
		{
			get
			{
				if (fullEntry == null)
				{
					return "Episoden";
				}
				return fullEntry.Category == "anime" ? "Episoden" : "Kapitel";
			}
		}

		public int SelectedContent
		{
			get { return selectedContent; }
			set { Set(ref selectedContent, value); }
		}

		public ObservableCollection<ContentWrapper> ContentCollection
		{
			get { return contentCollection; }
			set { Set(ref contentCollection, value); }
		}

		public int State
		{
			get { return state; }
			set { Set(ref state, value); }
		}

		private int selectedContent;

		private ObservableCollection<ContentWrapper> contentCollection;

		private int state;

		public int CurrentCommentPage { get; set; }

		public ObservableCollection<Comment> Comments
		{
			get { return comments; }
			set { Set(ref comments, value); }
		}

		public bool HasMoreComments
		{
			get { return hasMoreComments; }
			set { Set(ref hasMoreComments, value); }
		}

		public Relation SelectedRelation
		{
			get { return selectedRelation; }
			set { Set(ref selectedRelation, value); }
		}

		public ObservableCollection<Relation> Relations
		{
			get { return relations; }
			set { Set(ref relations, value); }
		}

		private ObservableCollection<Comment> comments;

		private bool hasMoreComments = true;

		private Relation selectedRelation;

		private ObservableCollection<Relation> relations;

		public bool RelationsLoaded { get; set; }
	}
}