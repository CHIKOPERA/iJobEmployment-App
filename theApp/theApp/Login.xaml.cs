using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
        }
        ClientObject client;
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new HomePage());
            // Created during registration
            lblErPassword.IsVisible = false;
            lblErUsername.IsVisible = false;
            if (App.Login=="Client")
            {
                if (!String.IsNullOrWhiteSpace(entryUsername.Text))
                {
                    if (!String.IsNullOrWhiteSpace(entryPassword.Text))
                    {
                        try
                        {
                            MailAddress email = new MailAddress(entryUsername.Text);
                        }
                        catch (Exception)
                        {

                            lblErUsername.Text = "Please enter a valid email address";
                            lblErUsername.IsVisible = true;

                            return;
                        }
                        try
                        {
                            HttpClient client = new HttpClient();
                            string url = $"http://ijobapp.azurewebsites.net/api/Login?Email={entryUsername.Text}&Password={entryPassword.Text}";
                            using (var httpClient = new HttpClient())
                            {
                                string json = await httpClient.GetStringAsync(url);
                                ClientObject clientObject = JsonConvert.DeserializeObject<ClientObject>(json);
                                if (clientObject != null)
                                {
                                    // await Navigation.PushAsync(new HomePage());
                                    await DisplayAlert("Login Successful", $"Welcome {clientObject.FirsName} {clientObject.Surname}, One request a day keeps your home immaculate", "OK");

                                    Client.ClientID = clientObject.ClientID;
                                    Client.FirsName = clientObject.FirsName;
                                    Client.Surname = clientObject.Surname;
                                    Client.DOB = clientObject.DOB;
                                    Client.Gender = clientObject.Gender;
                                    Client.StreetAddress = clientObject.StreetAddress;
                                    Client.City = clientObject.City;
                                    Client.Province = clientObject.Province;
                                    Client.ZipCode = clientObject.ZipCode;
                                    Client.Email = clientObject.Email;
                                    Client.Password = clientObject.Password;
                                    await Navigation.PushAsync(new HomePage());
                                }
                                else
                                {
                                    await DisplayAlert("Login Failed", $"Login failed, Wrong username or password ", "Ok");
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            await DisplayAlert("Try again", ex.Message, "OK");
                        }
                    }
                    else
                    {
                        lblErPassword.Text = "Fill in the password field!";
                        lblErPassword.IsVisible = true;
                    }
                }
                else
                {

                    lblErUsername.Text = "Fill in the username";
                    lblErUsername.IsVisible = true;
                }
            }
            else if (App.Login=="Driver")
            {
                //Do the code for the driver

                await Navigation.PushAsync(new DriverHomePage());
            }
          
            #region APICODE
            //if (!String.IsNullOrWhiteSpace(entryUsername.Text) && !String.IsNullOrWhiteSpace(entryPassword.Text))
            //{
            //    //^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$
            //    try
            //    {

            //        ClientObject client = new ClientObject();
            //        Client.Email = entryUsername.Text;
            //        Client.Password = entryPassword.Text;
            //        HttpClient httclient = new HttpClient();
            //        string url = $"<<<<<>>>>>>>->>>><<<>.http://ijobapp.azurewebsites.net/api/Client?email={client.Email}&Password={client.Password}";
            //        var uri = new Uri(url);
            //        httclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //        HttpResponseMessage response;
            //        var json = JsonConvert.SerializeObject(client);
            //        var content = new StringContent(json, Encoding.UTF8, "application/json");
            //        response = await httclient.PostAsync(uri, content);
            //        if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            //        {
            //            await Navigation.PushAsync(new HomePage());
            //        }
            //        else
            //        {
            //            bool wantsToRegister = await DisplayAlert("Profile not found", "Your profile is not registered. \n Do you want to register", "YES", "NO");
            //            if (wantsToRegister)
            //            {
            //                await Navigation.PushAsync(new RegisterPage());
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        await DisplayAlert("Connection Error", $"An error occured \n{ex.Message}","OK");
            //    }
            //}
            //else
            //{
            //   await DisplayAlert("Empty Fields","Please fill in all fields","OK");
            //} 
            #endregion
            #region 20190906
            //if (Client.ClientID == null)
            //{
            //    bool wantsToRegister = await DisplayAlert("No Profile  found on device", "No profile is  registered. \n Do you want to register", "YES", "NO");
            //    if (wantsToRegister)
            //    {
            //        await Navigation.PushAsync(new RegisterPage());
            //        return;
            //    }
            //}
            //else
            //{
            //    client = (ClientObject)Application.Current.Properties["Client"];

            //    if (client.Email == entryUsername.Text && client.Password == entryPassword.Text)
            //    {
            //        await Navigation.PopAsync();
            //        await Navigation.PushAsync(new HomePage());
            //    }
            //    else
            //    {
            //        bool wantsToRegister = await DisplayAlert("Login failed", "Email or Password incorrect. \n Do you want to register", "YES", "NO");
            //        if (wantsToRegister)
            //        {
            //            await Navigation.PushAsync(new RegisterPage());
            //        }
            //    }
            //} 
            #endregion
        }

        private  async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new RegisterPage());
            

        }
     
        private void BtnForgotPassword_Clicked(object sender, EventArgs e)
        {
            //Navigate to fogort password profile
        }
    }
}