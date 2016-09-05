using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Models;

namespace Proxer.Me.ViewModels
{
	public class LoginViewModel : ViewModel<LoginModel>
	{
		static LoginViewModel()
		{
			Instance = new LoginViewModel();
		}

		public static LoginViewModel Instance { get; private set; }

		public LoginViewModel() : base(new LoginModel())
		{
			
		}
	}
}
