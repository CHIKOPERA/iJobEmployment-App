using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignalArrivalPage : ContentPage
	{
		public SignalArrivalPage ()
		{
			InitializeComponent ();
		}

        private async void BtnArrived_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DriverHomePage());
        }
    }
}