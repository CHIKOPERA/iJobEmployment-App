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
	public partial class Feedback : ContentPage
	{
		public Feedback ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
        }

        private void BtnSend_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(entryBody.Text)&& !String.IsNullOrWhiteSpace(entrySubject.Text))
            {
                DisplayAlert("Sent", "Thank you for your feedback", "OK");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Email not sent","Email can not be sent without the subject or body","Ok");
                return;
            }
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}