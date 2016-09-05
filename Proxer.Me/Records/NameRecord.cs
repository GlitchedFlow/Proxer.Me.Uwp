using Proxer.Me.Core;
using Proxer.Me.ProxData.Info.Data;

namespace Proxer.Me.Records
{
	public class NameRecord : Notifier
	{
		private NameData _data;

		public NameData Data
		{
			get { return _data; }
			set
			{
				_data = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(nameof(Type));
			}
		}

		public string Type
		{
			get
			{
				if (Data?.Type == null)
				{
					return "Original Titel";
				}
				switch (Data.Type.ToLower())
				{
					case "name":
						return "Original Titel";

					case "namejap":
						return "Jap. Titel";

					case "nameeng":
						return "Eng. Titel";

					case "nameger":
						return "Deu. Titel";

					default:
						return "Synonym";
				}
			}
		}

		public NameRecord(NameData Data)
		{
			this.Data = Data;
		}
	}
}