using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Proxer.Me.Controls.Collections
{
	public class AutoLoadCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
	{
		#region Public Constructors

		public AutoLoadCollection(ICommand LoadMoreCommand)
		{
			loadMoreCommand = LoadMoreCommand;
		}

		#endregion Public Constructors

		#region Public Properties

		public bool HasMoreItems { get; set; } = false;

		public uint MinCallCount { get; set; } = 51;

		#endregion Public Properties

		#region Public Methods

		public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
		{
			//HasMoreItems = false;
			CoreDispatcher dispatcher = Window.Current.Dispatcher;

			currentCallCount += count;
			if (currentCallCount < MinCallCount || loadMoreCommand == null)
				return Task.Run(() => { return new LoadMoreItemsResult() { Count = count }; }).AsAsyncOperation();

			uint callCount = currentCallCount;
			currentCallCount = 0;

			return Task.Run(
				async () =>
				{
					await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
					{
						if (loadMoreCommand.CanExecute(null))
						{
							loadMoreCommand.Execute(null);
						}
					});

					return new LoadMoreItemsResult() { Count = callCount };
				}).AsAsyncOperation();
		}

		#endregion Public Methods

		#region Private Fields

		private ICommand loadMoreCommand;
		private uint currentCallCount = 0;

		#endregion Private Fields
	}
}