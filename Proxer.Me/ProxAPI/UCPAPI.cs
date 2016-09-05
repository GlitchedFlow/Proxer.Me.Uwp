using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxData.UCP;
using Proxer.Me.ProxSupport;
using Proxer.Me.ViewModels;

namespace Proxer.Me.ProxAPI
{
	public class UCPAPI
	{
		private const string ListURL = "https://proxer.me/api/v1/ucp/list";

		private const string ListSumURL = "https://proxer.me/api/v1/ucp/listsum";

		private const string TopTenURL = "https://proxer.me/api/v1/ucp/topten";

		private const string HistoryURL = "https://proxer.me/api/v1/ucp/history";

		private const string VoteURL = "https://proxer.me/api/v1/ucp/votes";

		private const string ReminderURL = "https://proxer.me/api/v1/ucp/reminder";

		private const string DelReminderURL = "https://proxer.me/api/v1/ucp/deletereminder";

		private const string DelFavoriteURL = "https://proxer.me/api/v1/ucp/deletefavorite";

		private const string DelVoteURL = "https://proxer.me/api/v1/ucp/deletevote";

		private const string CommentStateURL = "https://proxer.me/api/v1/ucp/setcommentstate";

		public static async Task<List> GetList(bool getManga = false, int page = 0, int limit = 100, string search = "", string search_start = "", Sort sort = Sort.stateNameASC)
		{
			var values = new Dictionary<string, string>
			{
				{ "kat", getManga == true ? "manga" : "anime" },
				{ "p", page.ToString() },
				{ "limit", limit.ToString() }
			};
			if (!string.IsNullOrWhiteSpace(search))
				values.Add("search", search);
			if (!string.IsNullOrWhiteSpace(search_start))
				values.Add("search_start", search_start);
			values.Add("sort", sort.ToString());

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(ListURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var list = JsonConvert.DeserializeObject<List>(responseString);
				return list;
			}
			else
			{
				return new List() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ListSum> GetListSum(bool getManga = false)
		{
			var values = new Dictionary<string, string>
			{
				{ "kat", getManga == true ? "manga" : "anime" },
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(ListSumURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var listSum = JsonConvert.DeserializeObject<ListSum>(responseString);
				return listSum;
			}
			else
			{
				return new ListSum() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<TopTen> GetTopTen()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(TopTenURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var topTen = JsonConvert.DeserializeObject<TopTen>(responseString);
				return topTen;
			}
			else
			{
				return new TopTen() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<History> GetHistory(int limit = 50, int page = 0)
		{
			var values = new Dictionary<string, string>
			{
				{ "limit", limit.ToString() },
				{ "p", page.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(HistoryURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var history = JsonConvert.DeserializeObject<History>(responseString);
				return history;
			}
			else
			{
				return new History() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Vote> GetVotes()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(VoteURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var votes = JsonConvert.DeserializeObject<Vote>(responseString);
				return votes;
			}
			else
			{
				return new Vote() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Reminder> GetReminder(bool getManga = false, int page = 0, int limit = 100)
		{
			var values = new Dictionary<string, string>
			{
				{ "kat", getManga == true ? "manga" : "anime" },
				{ "p", page.ToString() },
				{ "limit", limit.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(ReminderURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var reminder = JsonConvert.DeserializeObject<Reminder>(responseString);
				return reminder;
			}
			else
			{
				return new Reminder() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<DeleteReminder> SetDeleteReminder(int id)
		{
			var values = new Dictionary<string, string>
			{
				{ "id", id.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(DelReminderURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var delReminder = JsonConvert.DeserializeObject<DeleteReminder>(responseString);
				return delReminder;
			}
			else
			{
				return new DeleteReminder() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<DeleteFavorite> SetDeleteFavorite(int id)
		{
			var values = new Dictionary<string, string>
			{
				{ "id", id.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(DelFavoriteURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var delFavorite = JsonConvert.DeserializeObject<DeleteFavorite>(responseString);
				return delFavorite;
			}
			else
			{
				return new DeleteFavorite() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<DeleteVote> SetDeleteVote(int id)
		{
			var values = new Dictionary<string, string>
			{
				{ "id", id.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(DelVoteURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var deleteVote = JsonConvert.DeserializeObject<DeleteVote>(responseString);
				return deleteVote;
			}
			else
			{
				return new DeleteVote() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<CommentState> GetCommentState(int id, int value)
		{
			var values = new Dictionary<string, string>
			{
				{ "id", id.ToString() },
				{ "value", value.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(CommentStateURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var commentState = JsonConvert.DeserializeObject<CommentState>(responseString);
				return commentState;
			}
			else
			{
				return new CommentState() { Code = (int)response.StatusCode, Error = true };
			}
		}

	}
}
