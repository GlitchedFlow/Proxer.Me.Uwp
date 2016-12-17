using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Proxer.Me.Support.Api.Data.Info;
using Template10.Mvvm;

namespace Proxer.Me.Support.Records
{
	public class ContentWrapper : BindableBase
	{
		private bool isExpanded;

		public bool IsExpanded
		{
			get { return isExpanded; }
			set
			{
				Set(ref isExpanded, value);
				if (isExpanded && !ContentLoaded)
				{
					expandCommand?.Execute(this);
				}
			}
		}

		public string Title
		{
			get { return title; }
			set { Set(ref title, value); }
		}

		public bool ContentLoaded { get; set; } = false;

		public IEnumerable<IGrouping<string, Episode>> Content
		{
			get { return _content; }
			set { Set(ref _content, value); }
		}

		private IEnumerable<IGrouping<string, Episode>> _content;
		private string title;
		private ICommand expandCommand;

		public ContentWrapper(ICommand expandCommand)
		{
			if (expandCommand != null)
			{
				this.expandCommand = expandCommand;
			}
		}
	}
}