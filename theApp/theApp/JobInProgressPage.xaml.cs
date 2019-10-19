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
	public partial class JobInProgressPage : ContentPage
	{
		public JobInProgressPage ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
            int counter = 0;
            //Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            //{//Instead of time, read from the database and make sure the job has been completed
            //    counter++;
            //    if (counter==30)
            //    {
                   
            //        Navigation.PushAsync(new TransactionReportPage());
            //       // Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            //        return false;
            //    }
            //    return true;
            //});
           
        }

        private void BtnEndJOb_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransactionReportPage());
        }
    }
}