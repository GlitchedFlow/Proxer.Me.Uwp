using Proxer.Me.Support.Api;

namespace Proxer.Me.UWP.Core
{
	public static class ErrorHandler
	{
		public const string CaptchaURL = "https://www.proxer.me/misc/captcha";
		private const string unknownError = "Unbekannter Fehler";

		public static bool IsIPBlocked(ResponseData data)
		{
			if (data.Error)
				return data.Code == (int)Codes.IPBlocked ? true : false;
			return false;
		}

		public static bool IsHTTPError(ResponseData data)
		{
			if (data.Error)
			{
				return data.Code < 1000 ? true : false;
			}
			return false;
		}

		public static bool IsProxerError(ResponseData data)
		{
			if (data.Error)
			{
				return data.Code >= 1000 ? true : false;
			}
			return false;
		}

		public static string GetHTTPErrorText(ResponseData data)
		{
			switch (data.Code)
			{
				case (int)Codes.BadRequest:
					return "Bad Request.";

				case (int)Codes.Unauthorized:
					return "Nicht authoriziert.";

				case (int)Codes.Forbidden:
					return "Hierauf darfst du nicht zugreifen.";

				case (int)Codes.NotFound:
					return "Wo auch immer dieser hier ist, es existiert nicht.";

				case (int)Codes.InternalServerError:
					return "Interner Server Error (Da ist bei Proxer was schief gelaufen).";

				case (int)Codes.NotImplemented:
					return "Nicht implementiert.";

				case (int)Codes.BadGateway:
					return "Dieser Gateway war eine schlechte Wahl.";

				case (int)Codes.ServerUnavailable:
					return "Server nicht verfügbar. (Proxer down?)";

				case (int)Codes.GatewayTimeOut:
					return "TimeOut am Gateway.";

				case (int)Codes.HTTPVersionNotSupported:
					return "Schlechtes HTTP du gewählt hast.";

				case (int)Codes.NotExtended:
					return "Not Extended";

				case (int)Codes.AuthentificationRequired:
					return "Was auch immer du hier aufrufst, du bist dafür nicht authentifiziert.";
			}
			return unknownError;
		}

		public static string GetErrorMessage(ResponseData data)
		{
			if (IsHTTPError(data))
			{
				return GetHTTPErrorText(data);
			}
			else if (IsProxerError(data))
			{
				return data.Message;
			}
			return unknownError;
		}
	}
}