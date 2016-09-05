using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxSupport;
using Proxer.Me.ProxData.Info;

namespace Proxer.Me.ProxAPI
{
	public class InfoAPI
	{
		private const string EntryURL = "https://proxer.me/api/v1/info/entry";

		private const string NameURL = "https://proxer.me/api/v1/info/names";

		private const string GateURL = "https://proxer.me/api/v1/info/gate";

		private const string LangURL = "https://proxer.me/api/v1/info/lang";

		private const string SeasonURL = "https://proxer.me/api/v1/info/season";

		private const string GroupsURL = "https://proxer.me/api/v1/info/groups";

		private const string PublisherURL = "https://proxer.me/api/v1/info/publisher";

		private const string ListInfoURL = "https://proxer.me/api/v1/info/listinfo";

		private const string CommentsURL = "https://proxer.me/api/v1/info/comments";

		private const string RelationsURL = "https://proxer.me/api/v1/info/relations";

		private const string TagsURL = "https://proxer.me/api/v1/info/entrytags";

		private const string SetInfoURL = "https://proxer.me/api/v1/info/setuserinfo";

		public static async Task<Entry> GetEntry(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(EntryURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var entry = JsonConvert.DeserializeObject<Entry>(responseString);
				return entry;
			}
			else
			{
				return new Entry() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Name> GetNames(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(NameURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var names = JsonConvert.DeserializeObject<Name>(responseString);
				return names;
			}
			else
			{
				return new Name() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Gate> GetGate(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(GateURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var gate = JsonConvert.DeserializeObject<Gate>(responseString);
				return gate;
			}
			else
			{
				return new Gate() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Lang> GetLang(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(LangURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var lang = JsonConvert.DeserializeObject<Lang>(responseString);
				return lang;
			}
			else
			{
				return new Lang() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Season> GetSeason(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SeasonURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var season = JsonConvert.DeserializeObject<Season>(responseString);
				return season;
			}
			else
			{
				return new Season() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Group> GetGroups(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(GroupsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var group = JsonConvert.DeserializeObject<Group>(responseString);
				return group;
			}
			else
			{
				return new Group() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Publisher> GetPublisher(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(PublisherURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var publisher = JsonConvert.DeserializeObject<Publisher>(responseString);
				return publisher;
			}
			else
			{
				return new Publisher() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ListInfo> GetListInfo(int ID, int page = 0, int limit = 50)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() },
					{ "p", page.ToString() },
					{ "limit", limit.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(ListInfoURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var listInfo = JsonConvert.DeserializeObject<ListInfo>(responseString);
				return listInfo;
			}
			else
			{
				return new ListInfo() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Comment> GetComments(int ID, int page = 0, int limit = 25, bool sortRating = false)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() },
					{ "p", page.ToString() },
					{ "limit", limit.ToString() }
				};
			if (sortRating)
				values.Add("sort", "rating");

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(CommentsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var comment = JsonConvert.DeserializeObject<Comment>(responseString);
				return comment;
			}
			else
			{
				return new Comment() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Relation> GetRelations(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(RelationsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var relation = JsonConvert.DeserializeObject<Relation>(responseString);
				return relation;
			}
			else
			{
				return new Relation() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<EntryTag> GetTags(int ID)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(TagsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var tags = JsonConvert.DeserializeObject<EntryTag>(responseString);
				return tags;
			}
			else
			{
				return new EntryTag() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<UserInfo> SetInfo(int ID, InfoType type)
		{
			var values = new Dictionary<string, string>
				{
					{ "id", ID.ToString() },
					{ "type", type.ToString().ToLower() }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(SetInfoURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var info = JsonConvert.DeserializeObject<UserInfo>(responseString);
				return info;
			}
			else
			{
				return new UserInfo() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}