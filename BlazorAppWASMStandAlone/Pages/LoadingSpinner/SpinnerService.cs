using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace BlazorSpinner
{
	public class SpinnerService
	{
		//https://stackoverflow.com/questions/27918061/passing-a-task-as-parameter
		//_spinnerService.StaticShow(()=>MyHttpRequest.Test());
		public async void StaticShow(Func<Task> e_Func)
		{
			Show();
			await e_Func();
			Hide();

		}

        public event Action OnShow;
		public event Action OnHide;

		public void Show()
		{
			OnShow?.Invoke();
		}

		public void Hide()
		{
			OnHide?.Invoke();
		}
	}
}