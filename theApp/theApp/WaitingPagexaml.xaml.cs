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
	public partial class WaitingPagexaml : ContentPage
	{
        // private int hour=0, minute=1, secs=58;
      //  private bool isJobassigned = false;
         private static bool istimerOn = true;
		public WaitingPagexaml ()
		{
			InitializeComponent ();
            try
            {
                stackContents.HeightRequest = App.ScreenHeight;
                stackContents.WidthRequest = App.ScreenWidth;
               // time should be determined by the time start and time end
                int sec = 800;
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    lblEstTime.Text = sec.ToString();
                    sec--;
                    if (sec%8==0)
                    {
                        CheckAssignment(Client.ClientID);
                    }
                  
                    if (sec == 0)
                    {
                        DisplayAlert("Job unassigned", "Due to high labour demand, we could not find a labourer, please make another request", "OK");
                        Navigation.PushAsync(new HomePage());
                       return false;
                    }
                    return istimerOn;
                });
             
            }
            catch (Exception)
            {

                
            }

        }


        private async void CheckAssignment(string theID)
        {
            try
            {
                JobRequests jobRequests = new JobRequests();

                string url = $"http://ijobapp.azurewebsites.net/api/CheckAssigned?ClientID={theID}";

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
                        if (Client.isDriving==true)
                        {
                           //Navigate to Map
                        }
                        else if (Client.isDriving==false)
                        {
                            await DisplayAlert("Job Assigned", "Your job has been assigned, Please be patient while we transport your labourer/s", "Ok");
                            await Navigation.PushAsync(new JobInProgressPage());
                            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                            istimerOn = false;
                           //Navigate to map
                        }
                    }
                    else if (jobRequests.IsAssigned == false)
                    {
                        
                    }

                }
                else
                {
                    await DisplayAlert("No Job request found", $"There is no request that is reflecting in the syste, ", "Ok");
                }


            }
            catch (Exception ex)
            {

                await DisplayAlert("Try again", ex.Message, "OK");
            }
        }
        private void BtnCancelJob_Clicked(object sender, EventArgs e)
        {
            //   Navigation.PushAsync(new JobInProgressPage());
            DisplayAlert("Cancel Job","Your job will be cancelled. Do you want to procced","YES","NO");
        }

        private void BtnGoHome_Clicked(object sender, EventArgs e)
        {
           
       
        }
      
    }
}