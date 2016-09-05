using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxSupport;
using Proxer.Me.ProxData.User;

namespace Proxer.Me.ProxAPI
{
	public static class UserAPI
	{
		private const string LoginURL = "https://proxer.me/api/v1/user/login";

		private const string LogoutURL = "https://proxer.me/api/v1/user/logout";

		private const string UserinfoURL = "https://proxer.me/api/v1/user/userinfo";

		private const string TopTenURL = "https://proxer.me/api/v1/user/topten";

		private const string ListURL = "https://proxer.me/api/v1/user/list";

		private const string CommentsURL = "https://proxer.me/api/v1/user/comments";

		/// <summary>
		/// Logins the user.
		/// </summary>
		/// <param name="User">The user.</param>
		/// <param name="Password">The password.</param>
		/// <returns></returns>
		public static async Task<Login> LoginUser(string User, string Password)
		{
			var values = new Dictionary<string, string>
				{
					{ "username", User },
					{ "password", Password }
				};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(LoginURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var login = JsonConvert.DeserializeObject<Login>(responseString);
				return login;
			}
			else
			{
				return new Login() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Logouts the user.
		/// </summary>
		/// <returns></returns>
		public static async Task<Logout> LogoutUser()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(LogoutURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var logout = JsonConvert.DeserializeObject<Logout>(responseString);
				return logout;
			}
			else
			{
				return new Logout() { Error = true };
			}
		}

		/// <summary>
		/// Gets the user information.
		/// </summary>
		/// <param name="uid">The uid.</param>
		/// <returns></returns>
		public static async Task<UserInfo> GetUserInfo(int uid)
		{
			var values = new Dictionary<string, string>
			{
				{ "uid", uid.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(UserinfoURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var userinfo = JsonConvert.DeserializeObject<UserInfo>(responseString);
				return userinfo;
			}
			else
			{
				return new UserInfo() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Gets the information of the user that is logged in currently.
		/// </summary>
		public static async Task<UserInfo> GetUserInfo()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(UserinfoURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var userinfo = JsonConvert.DeserializeObject<UserInfo>(responseString);
				return userinfo;
			}
			else
			{
				return new UserInfo() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Gets the user information.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		public static async Task<UserInfo> GetUserInfo(string username)
		{
			var values = new Dictionary<string, string>
			{
				{ "username", username }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(UserinfoURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var userinfo = JsonConvert.DeserializeObject<UserInfo>(responseString);
				return userinfo;
			}
			else
			{
				return new UserInfo() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Gets the top ten.
		/// </summary>
		/// <param name="uid">The uid.</param>
		/// <param name="getManga">if set to <c>true</c> [get manga].</param>
		/// <returns></returns>
		public static async Task<TopTen> GetTopTen(int uid, bool getManga = false)
		{
			var values = new Dictionary<string, string>
			{
				{ "uid", uid.ToString() },
				{ "kat", getManga == true ? "manga" : "anime" }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(TopTenURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var topten = JsonConvert.DeserializeObject<TopTen>(responseString);
				return topten;
			}
			else
			{
				return new TopTen() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Gets the top ten.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="getManga">if set to <c>true</c> [get manga].</param>
		/// <returns></returns>
		public static async Task<TopTen> GetTopTen(string username, bool getManga = false)
		{
			var values = new Dictionary<string, string>
			{
				{ "username", username },
				{ "kat", getManga == true ? "manga" : "anime" }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(TopTenURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var topten = JsonConvert.DeserializeObject<TopTen>(responseString);
				return topten;
			}
			else
			{
				return new TopTen() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Lists the specified Infos.
		/// </summary>
		/// <param name="uid">The uid.</param>
		/// <param name="getManga">if set to <c>true</c> [get manga].</param>
		/// <param name="page">The page.</param>
		/// <param name="limit">The limit.</param>
		/// <param name="search">The search.</param>
		/// <param name="search_start">The search_start.</param>
		/// <param name="sort">The sort.</param>
		/// <returns></returns>
		public static async Task<List> GetList(int uid, bool getManga = false, int page = 0, int limit = 100, string search = "", string search_start = "", Sort sort = Sort.stateNameASC)
		{
			var values = new Dictionary<string, string>
			{
				{ "uid", uid.ToString() },
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

		/// <summary>
		/// Lists the specified Infos.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="getManga">if set to <c>true</c> [get manga].</param>
		/// <param name="page">The page.</param>
		/// <param name="limit">The limit.</param>
		/// <param name="search">The search.</param>
		/// <param name="search_start">The search_start.</param>
		/// <param name="sort">The sort.</param>
		/// <returns></returns>
		public static async Task<List> GetList(string username, bool getManga = false, int page = 0, int limit = 100, string search = "", string search_start = "", Sort sort = Sort.stateNameASC)
		{
			var values = new Dictionary<string, string>
			{
				{ "uid", username },
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

		/// <summary>
		/// Gets Comments
		/// </summary>
		/// <param name="uid">The uid.</param>
		/// <param name="getManga">if set to <c>true</c> [get manga].</param>
		/// <param name="page">The page.</param>
		/// <param name="limit">The limit.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public static async Task<Comments> GetComments(int uid, bool getManga = false, int page = 0, int limit = 100, int length = 0)
		{
			var values = new Dictionary<string, string>
			{
				{ "uid", uid.ToString() },
				{ "kat", getManga == true ? "manga" : "anime" },
				{ "p", page.ToString() },
				{ "limit", limit.ToString() },
				{ "length", length.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(CommentsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var comments = JsonConvert.DeserializeObject<Comments>(responseString);
				return comments;
			}
			else
			{
				return new Comments() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Gets Comments
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="getManga">if set to <c>true</c> [get manga].</param>
		/// <param name="page">The page.</param>
		/// <param name="limit">The limit.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public static async Task<Comments> GetComments(string username, bool getManga = false, int page = 0, int limit = 100, int length = 0)
		{
			var values = new Dictionary<string, string>
			{
				{ "username", username },
				{ "kat", getManga == true ? "manga" : "anime" },
				{ "p", page.ToString() },
				{ "limit", limit.ToString() },
				{ "length", length.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(CommentsURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var comments = JsonConvert.DeserializeObject<Comments>(responseString);
				return comments;
			}
			else
			{
				return new Comments() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}