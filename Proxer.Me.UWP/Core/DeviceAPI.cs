namespace Proxer.Me.UWP.Core
{
	public static class DeviceAPI
	{
		private const bool XboxAnimeAllowed = false;

		private const bool XboxMangaAllowed = false;

		private const bool DesktopAnimeAllowed = false;

		private const bool DesktopMangaAllowed = false;

		private const bool MobileAnimeAllowed = false;

		private const bool MobileMangaAllowed = true;

		private const string WindowsMobile = "Windows.Mobile";

		private const string WindowsXbox = "Windows.Xbox";

		private const string WindowsDesktop = "Windows.Desktop";

		public static bool AnimeAllowed()
		{
			switch (DeviceInfo.SystemFamily)
			{
				case WindowsMobile:
					return MobileAnimeAllowed;

				case WindowsDesktop:
					return DesktopAnimeAllowed;

				case WindowsXbox:
					return XboxAnimeAllowed;

				default:
					return false;
			}
		}

		public static bool MangaAllowed()
		{
			switch (DeviceInfo.SystemFamily)
			{
				case WindowsMobile:
					return MobileMangaAllowed;

				case WindowsDesktop:
					return DesktopMangaAllowed;

				case WindowsXbox:
					return XboxMangaAllowed;

				default:
					return false;
			}
		}
	}
}