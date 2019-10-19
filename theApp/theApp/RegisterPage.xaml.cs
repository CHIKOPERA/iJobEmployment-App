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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
        }

       
        private async  void BtnRegister_Clicked(object sender, EventArgs e)
        {
           
            if (isValideInput())
            {
                //   await Navigation.PopAsync();
                await Navigation.PushAsync(new ConfrmRegisration());
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new Login());
        }

        private bool isValideInput()
        {

            try
            {
                SwitchOffLabel();
                if (!String.IsNullOrWhiteSpace(enrtyID.Text))
                {
                    if (enrtyID.Text.Length == 13)
                    {
                        if (enrtyID.Text.Any(x => !char.IsLetter(x)))
                        {
                            if (!String.IsNullOrWhiteSpace(entryFirstName.Text))
                            {
                                if (!String.IsNullOrWhiteSpace(enrtySurname.Text))
                                {
                                    if (!String.IsNullOrWhiteSpace(enrtyStreetAddress.Text))
                                    {
                                        if (!String.IsNullOrWhiteSpace(entryCity.Text))
                                        {
                                            if (!String.IsNullOrWhiteSpace(entryProvince.Text ))
                                            {
                                                if (!String.IsNullOrWhiteSpace(entryZip.Text))
                                                {
                                                    if (entryZip.Text.Any(x=> char.IsDigit(x)) && entryZip.Text.Length==4)
                                                    {
                                                        if (!String.IsNullOrWhiteSpace(enrtyUsermame.Text))
                                                        {//email
                                                         //put emaeil regex
                                                            if (!String.IsNullOrWhiteSpace(enrtyPassword.Text) || !String.IsNullOrWhiteSpace(enrtyConfirmPass.Text))
                                                            {
                                                                if (enrtyPassword.Text == enrtyConfirmPass.Text)
                                                                {
                                                                    //fill the data
                                                                    Client.ClientID = enrtyID.Text;
                                                                    Client.FirsName = entryFirstName.Text;
                                                                    Client.Surname = enrtySurname.Text;
                                                                    Client.StreetAddress = enrtyStreetAddress.Text;
                                                                    Client.City = entryCity.Text;
                                                                    Client.Province = entryProvince.Text;
                                                                    Client.ZipCode = int.Parse(entryZip.Text);
                                                                    Client.Email = enrtyUsermame.Text;
                                                                    Client.Password = enrtyPassword.Text;
                                                                    SetAgeandSex(Client.ClientID);
                                                            
                                                                    return true;
                                                                }
                                                                else
                                                                {

                                                                    ErrorMessage(lblErConfrmPass, "Passwords do not match");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //   Alert("Passwords");
                                                                ErrorMessage(lblErPass, "Password field is empty");
                                                                return false;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            //Alert("Email");
                                                            ErrorMessage(lblErUsername, "Email field is epmty");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ErrorMessage(lblErAdrs, "Zip code should be a 4 numeric digit");
                                                    }
                                                }
                                                else
                                                {
                                                    // Alert("Postal Code");
                                                    ErrorMessage(lblErAdrs, "Postal code Field Empty");
                                                }
                                            }
                                            else
                                            {
                                                // Alert("Province");
                                                ErrorMessage(lblErAdrs, "Province Field Empty");
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            // Alert("City");
                                            ErrorMessage(lblErAdrs, "City Field Empty");
                                        }
                                        return false;
                                    }
                                    else
                                    {
                                        //  Alert("Street Address");
                                        ErrorMessage(lblErStrtAdrs, "Address Field Empty");
                                        return false;
                                    }
                                }
                                else
                                {
                                    //Alert("Surname");
                                    ErrorMessage(lblErSurname, "Surname field empty");
                                    return false;
                                }
                            }
                            else
                            {
                                // Alert("Firt Name");
                                ErrorMessage(lblErFirstName, "First name field is empty");
                                return false;
                            }
                        }
                        else
                        {
                            ErrorMessage(lblErID, "ID number should have number only");
                            return false;
                        }
                    }
                    else
                    {
                        ErrorMessage(lblErID, "ID number should be 13 characters");
                        return false;
                    }
                }
                else
                {
                    // Alert("Identiy Number");
                    ErrorMessage(lblErID, "ID Field is empty");
                    return false;
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Ëxception", ex.Message, "OKAY");
            }
            return false;
        }

        private void Alert(string control)
        {
            DisplayAlert("Empty Field", $"Please fill in the {control}", "OK");

        }
      
        private void ErrorMessage(Label label,View view)
        {
            label.IsVisible = true;
           
        }
        private void ErrorMessage(Label label,string message)
        {          
            label.Text = message;            
            label.IsVisible = true;
           
            
        }

        private void SetAgeandSex(string IDnumber)
        {//set the Date of birth and sex basing on the South African ID number
            try
            {//Logic needs to be worked on

                string dob= "19" + IDnumber.Substring(0, 2)+"-"+ IDnumber.Substring(2, 2)+"-"+ IDnumber.Substring(4, 2);
                Client.DOB = dob;
                if (int.Parse(IDnumber.Substring(6, 4)) > 4999)
                {
                    Client.Gender = "Male";
                }
                else
                {
                    Client.Gender = "Female";
                }

            }
            catch (Exception ex)
            {

               DisplayAlert("Exception",ex.Message,"Ok");
            }
        }
        private void SwitchOffLabel()
        {
            lblErConfrmPass.IsVisible = false;
            lblErFirstName.IsVisible = false;
            lblErID.IsVisible = false;
            lblErPass.IsVisible = false;
            lblErStrtAdrs.IsVisible = false;
            lblErSurname.IsVisible = false;
            lblErUsername.IsVisible = false;
            lblErAdrs.IsVisible = false;
        }
        private void EnrtyID_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Disallow letters;

        }

        private void BtnHelp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpRegPage());
        }
    }
}