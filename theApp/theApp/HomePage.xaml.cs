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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
       

        }

        private async void BtnCommenr_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Feedback());

        }

        private async  void BtnAddRequest_Clicked(object sender, EventArgs e)
        {


            await Navigation.PushAsync(new RequestPage());
       

        }

        private async void BtnProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientProfilePage());
        }

        private async void BtnReport_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ReportsPage());
        }

        private async void BtnHelp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }

        private void BtnHelp_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GeneralHelpPage());
        }

        private void BtnHelp2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomeHelpPage());
        }
    }
}