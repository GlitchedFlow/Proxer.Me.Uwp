using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.Models;

namespace Proxer.Me.ViewModels
{
	public class CaptchaViewModel : ViewModel<CaptchaModel>
	{
		static CaptchaViewModel()
		{
			Instance = new CaptchaViewModel();
		}

		public static CaptchaViewModel Instance { get; private set; }

		public CaptchaViewModel() : base(new CaptchaModel())
		{
		}
	}
}
