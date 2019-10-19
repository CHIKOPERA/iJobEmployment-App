using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfrmRegisration : ContentPage
	{
		public ConfrmRegisration ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
            try
            {
                lblID.Text = Client.ClientID;
                lblName.Text = Client.FirsName + " " + Client.Surname;
                lblGender.Text = Client.Gender;
                lblEmail.Text = Client.Email;
                lblDOB.Text = Client.DOB;
                lblAddress.Text = Client.StreetAddress + ", " + Client.City + ", " + Client.Province + ", " + Client.ZipCode.ToString();

            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.Message, "Okay");
            }
        }
        ClientObject client = new ClientObject();
        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Edit Registration","Edditing will require entering of all fields \n Are you sure you want to continue","Yes","No"))
            {
              await  Navigation.PopAsync();
              
            }
        }

        private async void BtnConfirm_Clicked(object sender, EventArgs e)
        {
            try
            {//Register the labouer using the cloud API
                HttpClient httpClient = new HttpClient();
                string url = $"http://ijobapp.azurewebsites.net/api/Client/{Client.ClientID}?Fname={Client.FirsName}&Lname={Client.Surname}&date={Client.DOB}&gender={Client.Gender}&street={Client.StreetAddress}&city={Client.City}&province={Client.Province}&postal_code={Client.ZipCode}&email={Client.Email}&password={Client.Password}";
                var uri = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                var json = JsonConvert.SerializeObject(client);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(uri, content);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    Application.Current.Properties["Client"] = client;
                    await DisplayAlert("Registered Successfully", "Your account has been successuly registered, please login and enjoy", "OK");
   
                    await Navigation.PushAsync(new Login());
                }
                else
                {
                    await DisplayAlert("Registration Failed", "Your registration was not successful, please check your internet connection", "OK");
                    

                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}