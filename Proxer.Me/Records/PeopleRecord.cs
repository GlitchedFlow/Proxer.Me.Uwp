using Proxer.Me.Core;
using Proxer.Me.ProxData.Info.Data;

namespace Proxer.Me.Records
{
	using Proxer.Me.Core;

	public class PeopleRecord : Notifier
	{
		private readonly bool isPublisher;

		private GroupData _group;

		private PublisherData _publisher;

		public PeopleRecord(GroupData data)
		{
			_group = data;
			isPublisher = false;
		}

		public PeopleRecord(PublisherData data)
		{
			_publisher = data;
			isPublisher = true;
		}

		public string Flag
		{
			get
			{
				if (IsPublisher)
				{
					switch (Publisher.Country)
					{
						case "de":
							return $"ms-appx:///Assets/Proxer/Flags/german.gif";

						case "us":
							return $"ms-appx:///Assets/Proxer/Flags/english.gif";

						default:
							return $"ms-appx:///Assets/Proxer/Flags/japanese.gif";
					}
				}
				switch (Group.Country)
				{
					case "de":
						return $"ms-appx:///Assets/Proxer/Flags/german.gif";

					case "us":
						return $"ms-appx:///Assets/Proxer/Flags/english.gif";

					default:
						return $"ms-appx:///Assets/Proxer/Flags/japanese.gif";
				}
			}
		}

		public GroupData Group
		{
			get { return _group; }
		}

		public bool IsPublisher
		{
			get { return isPublisher; }
		}

		public string Name
		{
			get
			{
				if (IsPublisher)
				{
					return Publisher.Name;
				}
				return Group.Name;
			}
		}

		public PublisherData Publisher
		{
			get { return _publisher; }
		}

		public string Type
		{
			get
			{
				if (IsPublisher)
				{
					if (string.IsNullOrEmpty(Publisher.Type))
					{
						return string.Empty;
					}
					return " (" + char.ToUpper(Publisher.Type[0]) + Publisher.Type.Substring(1) + ")";
				}
				return "";
			}
		}
	}
}