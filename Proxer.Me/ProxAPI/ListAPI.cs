using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxer.Me.Core;
using Proxer.Me.ProxSupport;
using Proxer.Me.ProxData.List;

namespace Proxer.Me.ProxAPI
{
	public class ListAPI
	{
		private const string EntrySearchURL = "https://proxer.me/api/v1/list/entrysearch";

		private const string EntryListURL = "https://proxer.me/api/v1/list/entrylist";

		private const string TagIDURL = "https://proxer.me/api/v1/list/tagids";

		private const string TagURL = "https://proxer.me/api/v1/list/tags";

		/// <summary>
		/// Search for Entries
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="Language">The language.</param>
		/// <param name="type">The type.</param>
		/// <param name="Genres">The genres.</param>
		/// <param name="IgnoreGenres">The ignore genres.</param>
		/// <param name="rating">The rating.</param>
		/// <param name="listsort">The listsort.</param>
		/// <param name="length">The length.</param>
		/// <param name="lengthlimit">The lengthlimit.</param>
		/// <param name="tags">The tags.</param>
		/// <param name="noTags">The no tags.</param>
		/// <param name="includeUnratedTags">if set to <c>true</c> [include unrated tags].</param>
		/// <param name="includeSpoilerTags">The include spoiler tags.</param>
		/// <param name="page">The page.</param>
		/// <param name="limit">The limit.</param>
		/// <returns></returns>
		public static async Task<EntrySearch> GetEntrySearch(string name = "",
			Language Language = Language.Both,
			ContentType type = ContentType.All,
			string[] Genres = null,
			string[] IgnoreGenres = null,
			FSK[] rating = null,
			ListSort listsort = ListSort.Relevance,
			int length = 0,
			LengthLimit lengthlimit = LengthLimit.Down,
			string[] tags = null,
			string[] noTags = null,
			bool includeUnratedTags = false,
			SpoilerTags includeSpoilerTags = SpoilerTags.Ignore,
			int page = 0,
			int limit = 100)
		{
			var values = new Dictionary<string, string>();
			if (!string.IsNullOrWhiteSpace(name))
				values.Add("name", name);
			switch (Language)
			{
				case Language.DE:
					values.Add("language", "de");
					break;
				case Language.EN:
					values.Add("language", "en");
					break;
				case Language.Both:
					values.Add("language", "beide");
					break;
			}
			switch (type)
			{
				case ContentType.AllAnimeWOH:
					values.Add("type", "all-anime");
					break;
				case ContentType.AllMAngaWOH:
					values.Add("type", "all-manga");
					break;
				case ContentType.AllWH:
					values.Add("type", "all18");
					break;
				default:
					values.Add("type", type.ToString().ToLower());
					break;
			}
			if (Genres != null)
			{
				var genres = "";
				foreach (var genre in Genres)
				{
					genres += genre + " ";
				}
				values.Add("genre", genres.Trim());
			}
			if (IgnoreGenres != null)
			{
				var genres = "";
				foreach (var genre in IgnoreGenres)
				{
					genres += genre + " ";
				}
				values.Add("nogenre", genres.Trim());
			}
			if (rating != null)
			{
				var rating_string = "";
				foreach (var rate in rating)
				{
					switch (rate)
					{
						case FSK.FSK0:
							rating_string += "fsk0 ";
							break;
						case FSK.FSK6:
							rating_string += "fsk6 ";
							break;
						case FSK.FSK12:
							rating_string += "fsk12 ";
							break;
						case FSK.FSK16:
							rating_string += "fsk16 ";
							break;
						case FSK.FSK18:
							rating_string += "fsk18 ";
							break;
						case FSK.BadLanguage:
							rating_string += "bad_language ";
							break;
						case FSK.Violence:
							rating_string += "violence ";
							break;
						case FSK.Fear:
							rating_string += "fear ";
							break;
						case FSK.Sex:
							rating_string += "sex ";
							break;
					}
				}
				values.Add("fsk", rating_string.Trim());
			}
			values.Add("sort", listsort.ToString().ToLower());
			values.Add("length", length.ToString());
			values.Add("length-limit", lengthlimit.ToString().ToLower());
			if (tags != null)
			{
				var tagstring = "";
				foreach (var tag in tags)
				{
					tagstring += tag + " ";
				}
				values.Add("tags", tagstring.Trim());
			}
			if (noTags != null)
			{
				var tagstring = "";
				foreach (var tag in noTags)
				{
					tagstring += tag + " ";
				}
				values.Add("notags", tagstring.Trim());
			}
			if (includeUnratedTags)
				values.Add("tagratefilter", "rate_10");
			else
				values.Add("tagratefilter", "rate_1");
			switch (includeSpoilerTags)
			{
				case SpoilerTags.ShowOnly:
					values.Add("tagspoilerfilter", "spoiler_1");
					break;
				case SpoilerTags.Ignore:
					values.Add("tagspoilerfilter", "spoiler_0");
					break;
				case SpoilerTags.ShowMixed:
					values.Add("tagspoilerfilter", "spoiler_10");
					break;
			}
			values.Add("p", page.ToString());
			values.Add("limit", limit.ToString());


			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(EntrySearchURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var entrySearch = JsonConvert.DeserializeObject<EntrySearch>(responseString);
				entrySearch.Data.ForEach(x => System.Diagnostics.Debug.WriteLine(x.Name));
				return entrySearch;
			}
			else
			{
				return new EntrySearch() { Code = (int)response.StatusCode, Error = true };
			}
		}


		/// <summary>
		/// List Entries
		/// </summary>
		/// <param name="getManga">if set to <c>true</c> [get manga].</param>
		/// <param name="medium">The medium.</param>
		/// <param name="showHentai">if set to <c>true</c> [show hentai].</param>
		/// <param name="start">The start.</param>
		/// <param name="page">The page.</param>
		/// <param name="limit">The limit.</param>
		/// <returns></returns>
		public static async Task<EntryList> GetEntryList(bool getManga = false, Medium medium = Medium.None, bool showHentai = false, string start = "", int page = 0, int limit = 100)
		{
			var values = new Dictionary<string, string>
			{
				{ "kat", getManga == true ? "manga" : "anime" }
			};
			if (medium != Medium.None)
				values.Add("medium", medium.ToString().ToLower());
			else
				values.Add("isH", showHentai.ToString().ToLower());
			if (!string.IsNullOrWhiteSpace(start))
				values.Add("start", start);
			values.Add("p", page.ToString());
			values.Add("limit", limit.ToString());

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(EntryListURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var entryList = JsonConvert.DeserializeObject<EntryList>(responseString);
				return entryList;
			}
			else
			{
				return new EntryList() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<TagID> GetTagIDs(string[] Tags)
		{
			var values = new Dictionary<string, string>();
			if (Tags != null)
			{
				var tagstring = "";
				foreach (var tag in Tags)
				{
					tagstring += tag + " ";
				}
				values.Add("search", tagstring.Trim());
			}

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(TagIDURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var tagID = JsonConvert.DeserializeObject<TagID>(responseString);
				return tagID;
			}
			else
			{
				return new TagID() { Code = (int)response.StatusCode, Error = true };
			}
		}

		public static async Task<Tag> GetTags(string search = "", TagType tagType = TagType.All_WOH, TagSort tagSort = TagSort.Tag, SortType sortType = SortType.ASC, TagSubType tagSubType = TagSubType.Alle)
		{
			var values = new Dictionary<string, string>();
			if (!string.IsNullOrWhiteSpace(search))
				values.Add("search", search);
			if (tagType != TagType.All_WOH)
			{
				if (tagType != TagType.All)
				{
					values.Add("type", tagType.ToString().ToLower());
				}
			}
			values.Add("sort", tagSort.ToString().ToLower());
			values.Add("sort_type", sortType.ToString().ToLower());
			if (tagSubType != TagSubType.Alle)
			{
				values.Add("subtype", tagSubType.ToString().ToLower());
			}

			var content = new FormUrlEncodedContent(values);

			var response = await ProxerClient.Instance.Client.PostAsync(TagURL, content);

			if (response.IsSuccessStatusCode)
			{
				var responseString = await response.Content.ReadAsStringAsync();

				var tag = JsonConvert.DeserializeObject<Tag>(responseString);
				return tag;
			}
			else
			{
				return new Tag() { Code = (int)response.StatusCode, Error = true };
			}
		}
	}
}
