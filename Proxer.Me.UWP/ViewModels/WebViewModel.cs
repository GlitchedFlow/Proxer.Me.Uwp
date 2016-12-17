using System.Collections.Generic;
using System.Threading.Tasks;
using Proxer.Me.UWP.Models;
using Windows.UI.Xaml.Navigation;

namespace Proxer.Me.UWP.ViewModels
{
	public class WebViewModel : ProxerViewModel<WebModel>
	{
		public WebViewModel() : base(new WebModel())
		{
		}

		public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			Model.Source = parameter.ToString();
			return Task.CompletedTask;
		}
	}
}