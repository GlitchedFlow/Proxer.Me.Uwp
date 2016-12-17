namespace Proxer.Me.Support.Api
{
	/// <summary>
	/// Bildet die JSON Antwort von Proxer als Object ab.
	/// </summary>
	/// <typeparam name="T">
	/// Der Type den Proxer in der Antwort in Data verwendet.
	/// </typeparam>
	public class ResponseData<T> : ResponseData
	{
		public new T Data { get; set; }
	}

	/// <summary>
	/// Bildet die JSON Antwort von Proxer als Object ab.
	/// </summary>
	public class ResponseData
	{
		public object Data { get; set; }

		public bool Error { get; set; }

		public int Code { get; set; }

		public string Message { get; set; }
	}
}