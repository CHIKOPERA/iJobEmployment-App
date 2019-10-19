using Rg.Plugins.Popup.Services;
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
	public partial class ClientProfilePage : ContentPage
	{
		public ClientProfilePage ()
		{
			InitializeComponent ();
            LoadData();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
            
		}

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new UpdateProfile(), true);
            
        }
        private void LoadData()
        {
            try
            {

                
                lblAddress.Text = $"{Client.StreetAddress}, {Client.City}, {Client.Province}";
                lblEmail.Text = Client.Email;
                lblName.Text = $"{Client.FirsName} {Client.Surname}";
                lblDOB.Text = Client.DOB;
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.Message, "Okay");
            }
        }
    }
}