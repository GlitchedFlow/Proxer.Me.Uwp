namespace Proxer.Me.Api
{
	internal class UrlCollection
	{
		internal static string ApiVersion = "v1";

		internal static string BaseURL = "https://proxer.me/api/";

		#region Anime

		internal static string AnimeStreams = $"{BaseURL}{ApiVersion}/anime/streams";

		internal static string AnimeProxerStreams = $"{BaseURL}{ApiVersion}/anime/proxerstreams";

		internal static string AnimeIncrementCount = $"{BaseURL}{ApiVersion}/anime/incrementcount";

		#endregion Anime

		#region Info

		internal static string InfoFullEntry = $"{BaseURL}{ApiVersion}/info/fullentry";

		internal static string InfoEntry = $"{BaseURL}{ApiVersion}/info/entry";

		internal static string InfoName = $"{BaseURL}{ApiVersion}/info/names";

		internal static string InfoGate = $"{BaseURL}{ApiVersion}/info/gate";

		internal static string InfoLang = $"{BaseURL}{ApiVersion}/info/lang";

		internal static string InfoSeason = $"{BaseURL}{ApiVersion}/info/season";

		internal static string InfoGroups = $"{BaseURL}{ApiVersion}/info/groups";

		internal static string InfoPublisher = $"{BaseURL}{ApiVersion}/info/publisher";

		internal static string InfoListInfo = $"{BaseURL}{ApiVersion}/info/listinfo";

		internal static string InfoComments = $"{BaseURL}{ApiVersion}/info/comments";

		internal static string InfoRelations = $"{BaseURL}{ApiVersion}/info/relations";

		internal static string InfoTags = $"{BaseURL}{ApiVersion}/info/entrytags";

		internal static string InfoSetInfo = $"{BaseURL}{ApiVersion}/info/setuserinfo";

		#endregion Info

		#region List

		internal static string ListEntrySearch = $"{BaseURL}{ApiVersion}/list/entrysearch";

		internal static string ListEntryList = $"{BaseURL}{ApiVersion}/list/entrylist";

		internal static string ListTagID = $"{BaseURL}{ApiVersion}/list/tagids";

		internal static string ListTag = $"{BaseURL}{ApiVersion}/list/tags";

		#endregion List

		#region Manga

		internal static string MangaChapter = $"{BaseURL}{ApiVersion}/manga/chapter";

		#endregion Manga

		#region Media

		internal static string MediaRandomHeader = $"{BaseURL}{ApiVersion}/media/randomheader";

		internal static string MediaHeaderList = $"{BaseURL}{ApiVersion}/media/headerlist";

		#endregion Media

		#region Messenger

		internal static string MessengerGetConstants = $"{BaseURL}{ApiVersion}/messenger/constants";

		internal static string MessengerGetConference = $"{BaseURL}{ApiVersion}/messenger/conferences";

		internal static string MessengerGetConferenceInfo = $"{BaseURL}{ApiVersion}/messenger/conferenceinfo";

		internal static string MessengerGetMessages = $"{BaseURL}{ApiVersion}/messenger/messages";

		internal static string MessengerGetUserInfo = $"{BaseURL}{ApiVersion}/messenger/userinfo";

		internal static string MessengerNewConference = $"{BaseURL}{ApiVersion}/messenger/newconference";

		internal static string MessengerNewConferenceGroup = $"{BaseURL}{ApiVersion}/messenger/newconferencegroup";

		internal static string MessengerSetReport = $"{BaseURL}{ApiVersion}/messenger/report";

		internal static string MessengerSetMessage = $"{BaseURL}{ApiVersion}/messenger/setmessage";

		internal static string MessengerSetUnread = $"{BaseURL}{ApiVersion}/messenger/setunread";

		internal static string MessengerSetBlock = $"{BaseURL}{ApiVersion}/messenger/setblock";

		internal static string MessengerSetUnblock = $"{BaseURL}{ApiVersion}/messenger/setunblock";

		internal static string MessengerSetFavour = $"{BaseURL}{ApiVersion}/messenger/setfavour";

		internal static string MessengerSetUnfavour = $"{BaseURL}{ApiVersion}/messenger/setunfavour";

		#endregion Messenger

		#region Notifications

		internal static string NotificationsCount = $"{BaseURL}{ApiVersion}/notifications/count";

		internal static string NotificationsNews = $"{BaseURL}{ApiVersion}/notifications/news";

		internal static string NotificationsDelete = $"{BaseURL}{ApiVersion}/notifications/delete";

		#endregion Notifications

		#region UCP

		internal static string UCPList = $"{BaseURL}{ApiVersion}/ucp/list";

		internal static string UCPListSum = $"{BaseURL}{ApiVersion}/ucp/listsum";

		internal static string UCPTopTen = $"{BaseURL}{ApiVersion}/ucp/topten";

		internal static string UCPHistory = $"{BaseURL}{ApiVersion}/ucp/history";

		internal static string UCPVote = $"{BaseURL}{ApiVersion}/ucp/votes";

		internal static string UCPReminder = $"{BaseURL}{ApiVersion}/ucp/reminder";

		internal static string UCPDelReminder = $"{BaseURL}{ApiVersion}/ucp/deletereminder";

		internal static string UCPDelFavorite = $"{BaseURL}{ApiVersion}/ucp/deletefavorite";

		internal static string UCPDelVote = $"{BaseURL}{ApiVersion}/ucp/deletevote";

		internal static string UCPSetCommentState = $"{BaseURL}{ApiVersion}/ucp/setcommentstate";

		internal static string UCPSetReminder = $"{BaseURL}{ApiVersion}/ucp/setreminder";

		#endregion UCP

		#region User

		internal static string UserLogin = $"{BaseURL}{ApiVersion}/user/login";

		internal static string UserLogout = $"{BaseURL}{ApiVersion}/user/logout";

		internal static string UserUserinfo = $"{BaseURL}{ApiVersion}/user/userinfo";

		internal static string UserTopTen = $"{BaseURL}{ApiVersion}/user/topten";

		internal static string UserList = $"{BaseURL}{ApiVersion}/user/list";

		internal static string UserComments = $"{BaseURL}{ApiVersion}/user/comments";

		#endregion User
	}
}