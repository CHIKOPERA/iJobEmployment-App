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
	public partial class ViewReportPage : Rg.Plugins.Popup.Pages.PopupPage
    {
		public ViewReportPage ()

		{
            InitializeComponent ();
            try
            {
           
                lblDate.Text = JobRequestReport.jobRequestList[JobRequestReport.selectedndex].Date;
                lblCOst.Text = JobRequestReport.jobRequestList[JobRequestReport.selectedndex].Cost.ToString();
                lblJobSpec.Text = JobRequestReport.jobRequestList[JobRequestReport.selectedndex].JobSpec;
                LblLocation.Text = JobRequestReport.jobRequestList[JobRequestReport.selectedndex].Location;
                lblCategory.Text = JobRequestReport.jobRequestList[JobRequestReport.selectedndex].Category;
                

                //used for demostration[execution time] =>actuual will comes form the database
                lblAssigned.Text = "Assigned by iJOb Agency";
        
           
             //   Random rand = new Random();
                #region .
                lblAssignedBy.Text = "Tanya ";

                List<string> labList = new   List<string>();
                labList.Add("Man Chester"); labList.Add("Henry Thompson"); labList.Add("Thandolwethu  Bottoman"); labList.Add("Tanya Puwani");
                #endregion
                for (int i = 0; i <= JobRequestReport.jobRequestList[JobRequestReport.selectedndex].NumOfLabs; i++)
                {
                    lblLabs.Text += labList[i].ToString();
                }


            }
            catch (Exception e )
            {

                DisplayAlert("Exeception",e.Message,"OKAY");
            }
		}

     

        private void BtnOkay_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}