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
	public partial class SplashPage : ContentPage
	{
		public SplashPage ()
		{
			InitializeComponent ();
            //  Load();
         


         

        }
     

        private async void Client_Clicked(object sender, EventArgs e)
        {
            App.Login = "Client";
            await Navigation.PushAsync(new Login());
            // Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count-1]);
              
         
        }

        private async void BtnDriver_Clicked(object sender, EventArgs e)
        {
            App.Login = "Driver";
            await Navigation.PushAsync(new Login());
        }
    }
}