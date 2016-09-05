using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxer.Me.ProxSupport
{
	public enum Codes
	{
		BadRequest = 400,
		Unauthorized = 401,
		Forbidden = 403,
		NotFound = 404,

		InternalServerError = 500,
		NotImplemented = 501,
		BadGateway = 502,
		ServerUnavailable = 503,
		GatewayTimeOut = 504,
		HTTPVersionNotSupported = 505,
		NotExtended = 510,
		AuthentificationRequired = 511,

		APIVersionNotFound = 1000,
		APIVersionDeleted = 1001,
		APIClassNotFound = 1002,
		APIFunctionNotFound = 1003,
		APIKeyAccessLevelToLow = 1004,
		ExpiredToken = 1005,
		FunktionLocked = 1006,

		IPBlocked = 2000,
		NewsError = 2001,

		LoginDataMissing = 3000,
		LoginDataWrong = 3001,
		UserNotLoggedIn_Notification = 3002,
		UnknownUser = 3003,
		UserNotLoggedIn_UCP = 3004,
		CategoryNotFound_UCP = 3005,
		UnknownID_UCP = 3006,
		UnknownID_Info = 3007,
		WrongType = 3008,
		UserNotLoggedIn_Info = 3009,
		EntryAlreadyInList = 3010,
		MaximumAmountOfFavs = 3011,
		UserAlreadyLoggedIn = 3012,
		DiffrentUserAlreadyLoggedIn = 3013,
		AccessDenied = 3014,
		CategoryNotFound_List = 3015,
		MediumNotFound = 3016,
		StyleNotFound = 3017,
		EntryNotFound = 3018,
		ChapterNotUploaded = 3019,
		EpisodeNotUploaded = 3020,
		StreamNotFound = 3021,
		EpisodeNotFound = 3022,
		UserNotLoggedIn_Messenger = 3023,
		UnknownID_Messenger = 3024,
		UnknownReason_Messenger = 3025,
		UnknownMessage_Messenger = 3026,
		UnknownReciever = 3027,
		MaxAmountOfUserReached = 3028,
		UnknownSubject = 3029,
		NotEnoughUser = 3030
	}
}
