using System;

namespace Proxer.Me.Support.Attributes
{
	public sealed class GenreNameAttribute : Attribute
	{
		public string DisplayName { get; }

		public string ApiName { get; }

		public GenreNameAttribute(string displayName, string apiName)
		{
			DisplayName = displayName;
			ApiName = apiName;
		}
	}
}