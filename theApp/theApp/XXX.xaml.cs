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
	public partial class XXX : ContentPage
	{
		public XXX ()
		{
			InitializeComponent ();
		}
        private async void BtnClick_Clicked(object sender, EventArgs e)
        {
            //CheckStatus(txtInput.Text);
            //DisplayAlert("test",isJobassigned.ToString(),"ok");
            try
            {
                JobRequests jobRequests = new JobRequests();

                string url = $"http://ijobapp.azurewebsites.net/api/CheckAssigned?ClientID={txtInput.Text}";

                HttpClient client = new HttpClient();
                string json = await client.GetStringAsync(url);
                //ConfigureAwait(false);
                JobRequests jobRequestss = JsonConvert.DeserializeObject<JobRequests>(json);
                if (jobRequestss != null)
                {
                    // await Navigation.PushAsync(new HomePage());

                    jobRequests.ClientID = jobRequestss.ClientID;
                    jobRequests.Date = jobRequestss.Date;
                    jobRequests.TimeStart = jobRequestss.TimeStart;
                    jobRequests.TimeEnd = jobRequestss.TimeEnd;
                    jobRequests.Category = jobRequestss.Category;
                    jobRequests.NumOfLabs = jobRequestss.NumOfLabs;
                    jobRequests.JobSpec = jobRequestss.JobSpec;
                    jobRequests.Location = jobRequestss.Location;
                    jobRequests.TranspotStatus = jobRequestss.TranspotStatus;
                    jobRequests.IsAssigned = jobRequestss.IsAssigned;
                    jobRequests.Cost = jobRequestss.Cost;

                    if (jobRequests.IsAssigned == true)
                    {
                        await DisplayAlert("In", "We are in", "OK");
                    }
                    else if (jobRequests.IsAssigned == false)
                    {
                        await DisplayAlert("Out", "We are out", "OK");
                    }

                }
                else
                {
                    await DisplayAlert("No Job request like that Failed", $"Hakuna request yakadaro ", "Ok");
                }


            }
            catch (Exception ex)
            {

                await DisplayAlert("Try again", ex.Message, "OK");
            }
        }

        
       
    }
}