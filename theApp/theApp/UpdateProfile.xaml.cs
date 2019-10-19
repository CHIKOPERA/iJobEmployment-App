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
	public partial class UpdateProfile : Rg.Plugins.Popup.Pages.PopupPage
	{
		public UpdateProfile ()
		{
			InitializeComponent ();
         
            try
            {
                entryCity.Text = Client.City;
                enrtyStreetAddress.Text = Client.StreetAddress;
                entryProvince.Text = Client.Province;
                entryZip.Text = Client.ZipCode.ToString();
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.Message, "OK");
            }

        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            SwitchOffLabels();
            if (isValidated())
            {
                try
                {
                    Client.Province = entryProvince.Text;
                    Client.StreetAddress = enrtyStreetAddress.Text;
                    Client.ZipCode = int.Parse(entryZip.Text);
                    Client.City = entryCity.Text;
                    PopupNavigation.Instance.PopAsync();
                }
                catch (Exception ex)
                {

                    DisplayAlert("Error", ex.Message, "OK");
                }
               
            }
           
        }
        private void SwitchOffLabels()
        {
            lblErAdrs.IsVisible = false;
            lblErConfirmPass.IsVisible = false;
            lblErNewPass.IsVisible = false;
            lblErOldPass.IsVisible = false;
            lblErStrtAdrs.IsVisible = false;

        }
        private void ErrorMessage(Label label,string msg)
        {
            label.IsVisible = true;
            label.Text = msg;
        }
        private void BtnUpdatePassowd_Clicked(object sender, EventArgs e)
        {
            if (stackPassword.IsVisible == true)
            {
                stackPassword.IsVisible = false;
            }
            else
            {
                stackPassword.IsVisible = true;
            }
        }
      
        private bool isValidated()
        {
            if (!String.IsNullOrEmpty(enrtyStreetAddress.Text))
            {
                if (!String.IsNullOrWhiteSpace(entryCity.Text))
                {
                    if (!String.IsNullOrWhiteSpace(entryProvince.Text))
                    {
                        if (!String.IsNullOrWhiteSpace(entryZip.Text))
                        {
                            if (entryZip.Text.Length == 4)
                            {
                                if (entryZip.Text.Any(x => char.IsDigit(x)))
                                {
                                    /////////
                                    if (stackPassword.IsVisible==true)
                                    {
                                        if (!String.IsNullOrWhiteSpace(enrtyOldPassword.Text))
                                        {
                                            if (!String.IsNullOrWhiteSpace(enrtyNewPass.Text))
                                            {
                                                if (!String.IsNullOrWhiteSpace(enrtyConfirmPass.Text))
                                                {
                                                    if (enrtyOldPassword.Text==Client.Password)
                                                    {
                                                        if (enrtyNewPass.Text==enrtyConfirmPass.Text)
                                                        {
                                                            Client.Password = enrtyNewPass.Text;

                                                        }
                                                        else
                                                        {
                                                            ErrorMessage(lblErConfirmPass, "Password does not match");
                                                            ErrorMessage(lblErNewPass, "Password does not match");
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ErrorMessage(lblErOldPass, "Password is incorrect");
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    ErrorMessage(lblErConfirmPass, "Please fill in the confirm password field");
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                ErrorMessage(lblErNewPass, "Please fill the new password");
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            ErrorMessage(lblErOldPass, "Please fill the old password");
                                            return false;
                                        }
                                    }
                                    //////////////////////
                                    return true;
                                    /////////////////////////
                                }
                                else
                                {
                                    ErrorMessage(lblErAdrs, "Zip code should be a numeric value");
                                    return false;
                                }
                            }
                            else
                            {
                                ErrorMessage(lblErAdrs, "Zip Code must be 4 characters");
                                return false;
                            }
                        }
                        else
                        {
                            ErrorMessage(lblErAdrs, "Please fill in the Zip code");
                            return false;
                        }
                    }
                    else
                    {
                        ErrorMessage(lblErAdrs, "Please fill in the province field");
                        return false;
                    }
                }
                else
                {
                    ErrorMessage(lblErAdrs, "Please fill in the city field");
                    return false;
                }
            }
            else
            {
                ErrorMessage(lblErStrtAdrs, "Please fill the street");
                return false;
            }
        }
    }
}