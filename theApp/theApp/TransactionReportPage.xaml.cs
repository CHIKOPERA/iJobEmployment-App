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
	public partial class TransactionReportPage : ContentPage
	{
		public TransactionReportPage ()
		{
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
            //Add the transaction report

            try
            {
                int lastIndex = JobRequestReport.jobRequestList.Count() - 1;
                lblDate.Text = JobRequestReport.jobRequestList[lastIndex].Date.ToString();
                lblCategory.Text = JobRequestReport.jobRequestList[lastIndex].Category.ToString();
                listViewLabouers.ItemsSource = JobRequestReport.Labourers;
            }
            catch (Exception ex)
            {

                DisplayAlert("Error",ex.Message,"Ok");
            }
            

        }

        private async void BtnGoHome_Clicked(object sender, EventArgs e)
        {
           await    PopupNavigation.Instance.PushAsync(new RatingPopup(), true);      
           await  Navigation.PushAsync(new HomePage());
           Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

        }
    }
}