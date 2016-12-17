using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Support.Api;
using Proxer.Me.Support.Api.Data.Common;
using Proxer.Me.Support.Api.Data.User;

namespace Proxer.Me.Api.Getter
{
	public static class UserAPI
	{
		#region Public Methods

		public static async Task<ResponseData<List<Comment>>> GetComments(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UserComments, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var comments = JsonConvert.DeserializeObject<ResponseData<List<Comment>>>(responseString);
				return comments;
			}
			else
			{
				return new ResponseData<List<Comment>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<List>>> GetList(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UserList, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var list = JsonConvert.DeserializeObject<ResponseData<List<List>>>(responseString);
				return list;
			}
			else
			{
				return new ResponseData<List<List>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<List<TopTen>>> GetTopTen(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UserTopTen, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var topten = JsonConvert.DeserializeObject<ResponseData<List<TopTen>>>(responseString);
				return topten;
			}
			else
			{
				return new ResponseData<List<TopTen>>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<UserInfo>> GetUserInfo(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UserUserinfo, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var userinfo = JsonConvert.DeserializeObject<ResponseData<UserInfo>>(responseString);
				return userinfo;
			}
			else
			{
				return new ResponseData<UserInfo>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		/// <summary>
		/// Gets the information of the user that is logged in currently.
		/// </summary>
		public static async Task<ResponseData<UserInfo>> GetUserInfo()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UserUserinfo, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var userinfo = JsonConvert.DeserializeObject<ResponseData<UserInfo>>(responseString);
				return userinfo;
			}
			else
			{
				return new ResponseData<UserInfo>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData<Login>> LoginUser(IDictionary<string, string> postParas)
		{
			var content = new FormUrlEncodedContent(postParas);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UserLogin, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var login = JsonConvert.DeserializeObject<ResponseData<Login>>(responseString);
				return login;
			}
			else
			{
				return new ResponseData<Login>() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<ResponseData> LogoutUser()
		{
			var values = new Dictionary<string, string>();

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Client.PostAsync(UrlCollection.UserLogout, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var logout = JsonConvert.DeserializeObject<ResponseData>(responseString);
				return logout;
			}
			else
			{
				return new ResponseData() { Error = true };
			}
		}

		#endregion Public Methods
	}
}