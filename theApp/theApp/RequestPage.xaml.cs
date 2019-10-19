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
	public partial class RequestPage : ContentPage
	{
		public RequestPage ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
            datePicker.MinimumDate = DateTime.Now;
     
		}
     
        JobRequest jobRequest = new JobRequest();

    private void Clear()
        {
            entryJobSpec.Text = "";
            entryLocation.Text = "";
            
        }

        private async void BtnRequest_Clicked(object sender, EventArgs e)
        {
          
          //  jobRequest.ClientID = "1199861119159";
            if (ValidateData())
            {
                //Payment is sent 

                try
                {
                    HttpClient client = new HttpClient();
                    string url = $"http://ijobapp.azurewebsites.net/api/MakeRequest/{jobRequest.ClientID}?date={jobRequest.Date}&timeStart={jobRequest.TimeStart}&timeEnd={jobRequest.TimeEnd}&transport={jobRequest.TranspotStatus}&category={jobRequest.Category}&numOfLab={jobRequest.NumOfLabs}&location={jobRequest.Location}&cost={jobRequest.Cost}&jobSpec={jobRequest.JobSpec}";
                    var uri = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response;
                    var json = JsonConvert.SerializeObject(jobRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync(uri, content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        //Add job request to list of job request
                        JobRequestReport.jobRequestList.Add(jobRequest);
                        await DisplayAlert("Request sent", "Your request has been sent", "OK");
                        
                        if (jobRequest.TranspotStatus == true)
                        {//if they are picking up, they should see a map
                            Client.isDriving = true;//Change the option to driving
                           await Navigation.PushAsync(new WaitingPagexaml());
                           Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

                            // await Navigation.PopAsync();

                        }
                        else
                        {//If the client is  not piccking the labourer, they are taken to the waiting page
                            Client.isDriving = false;//Change the option to agency driver
                            await Navigation.PushAsync(new WaitingPagexaml());
                            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

                            //  await Navigation.PopAsync();
                        }

                    }
                    else
                    {
                        await DisplayAlert("Request not sent", $"Your request has not been sent,Please ensure that you have a working internet connection the status code is :=>{response.StatusCode.ToString()}", "OK");

                    }

                }
                catch (Exception ex)
                {

                    await DisplayAlert("Exeception", ex.Message, "OK");
                }
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
         
            await Navigation.PushAsync(new HomePage());
        }

      
        private bool ValidateData()
        {
            if (!String.IsNullOrWhiteSpace(entryJobSpec.Text))
            {

                if (!String.IsNullOrWhiteSpace(entryLocation.Text))
                {
                    if (pickerNUmOfLabourers.SelectedItem != null)
                    {
                        if (pickerCategory.SelectedItem != null)
                        {
                            Random random = new Random();
                            jobRequest.ClientID = Client.ClientID;
                            jobRequest.Date = datePicker.Date.ToShortDateString();
                            jobRequest.TimeStart = timeStartPicker.Time.ToString();
                            jobRequest.TimeEnd = timeEndPicker.Time.ToString();
                            jobRequest.Category = pickerCategory.SelectedItem.ToString();
                            jobRequest.NumOfLabs = int.Parse(pickerNUmOfLabourers.SelectedItem.ToString());
                            jobRequest.JobSpec = entryJobSpec.Text;
                            jobRequest.Cost = (decimal)(random.Next(100*jobRequest.NumOfLabs,300 * jobRequest.NumOfLabs));
                         
                            jobRequest.Location = entryLocation.Text;

                            if (isTraportProvided.IsToggled == true)
                            {
                                jobRequest.TranspotStatus = true;
                            }
                            jobRequest.IsAssigned = false;
                            lblCost.Text = "R "+jobRequest.Cost.ToString()+".00";
                       

                           
                           
                        }
                        else
                        {
                          
                            ErrorMessage(lblErCateory, "Please fill in category");
                            return false;

                        }
                    }
                    else
                    {
                       
                        ErrorMessage(lblErNumOfLab, "Please fil in the number of labourers");
                        return false;
                    }
                }
                else
                {
                    
                    ErrorMessage(lblErLocation, "Please fill in the location field");
                    return false;
                }
            }
            else
            {
                
                ErrorMessage(lblErJobSpec, "Please fill in the job Specification");
                return false;
            }
            return true;    

        }
      
        private void ErrorMessage(Label label, string message)
        {
            label.Text = message;
            label.IsVisible = true;


        }
        private void SwitchLabelOff()
        {
            lblErJobSpec.IsVisible = false;
            lblErLocation.IsVisible = false;
            lblErCateory.IsVisible = false;
            lblErNumOfLab.IsVisible = false;
            
        }
        private void PickerCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void BtnHelp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpRequestPage());
        }
    }
}
