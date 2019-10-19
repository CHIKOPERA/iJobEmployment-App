using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace theApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportsPage : ContentPage
	{
		public ReportsPage ()
		{    
			InitializeComponent ();
            stackContents.HeightRequest = App.ScreenHeight;
            stackContents.WidthRequest = App.ScreenWidth;
            listViewReports.ItemsSource = JobRequestReport.jobRequestList;
		}

        private void BtnConfirm_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("index Test",JobRequestReport.jobRequestList[listViewReports.SelectedItem["Ok");
            //DisplayAlert("Index Test",JobRequestReport.jobRequestList[listViewReports.GetChildElements(ListView).FirstOrDefault(x => int.Parse(x.StyleId)==JobRequestReport.index)].Date,"OK");
            
        }

      
        
        private void TextCell_Tapped_1(object sender, EventArgs e)
        {
            JobRequestReport.selectedndex = JobRequestReport.jobRequestList.IndexOf(listViewReports.SelectedItem);
        
            PopupNavigation.Instance.PushAsync(new ViewReportPage(), true);

        }
 
    }
}